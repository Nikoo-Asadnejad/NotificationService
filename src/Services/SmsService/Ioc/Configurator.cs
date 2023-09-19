using System.Reflection;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using SmsService.Interfaces;
using SmsService.Services;
using SmsContract.Enums;
using SmsService.Consumers;

namespace SmsService.Configurations;

public static class Configurator
{
    public static void InjectService(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<ISmsService,SendSmsService>();
        services.AddTransient<Func<Provider, ISmsProvider>>(servideProvider => provider =>
        provider switch
            {
                Provider.Kavenegar => servideProvider.GetService<KaveNegarProvider>(),
                _ => servideProvider.GetService<KaveNegarProvider>(),
            });
        
        var appSetting = new AppSetting();
        configuration.Bind(appSetting);
        Configuration.AppSetting = appSetting;
        
        AddLogging(configuration);
    }

    public static void AddRabbitConsumer(this IServiceCollection services)
    =>services.AddMassTransit(configurator =>
    {
        var rabbitSetting = Configuration.AppSetting.RabbitMqSetting;
        configurator.UsingRabbitMq();
        configurator.AddConsumer<SmsConsumer>();
        configurator.AddBus(provider => 
            Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri(rabbitSetting.Url), h =>
            {
                h.Username(rabbitSetting.UserName);
                h.Password(rabbitSetting.Password);
            });
            cfg.ReceiveEndpoint("smsQueue", ep =>
            {
                ep.PrefetchCount = 16;
                ep.Durable = true;
                ep.UseMessageRetry(r => r.Interval(2, 100));
                ep.ConfigureConsumer<SmsConsumer>(provider);
            });
        }));
    });
    public static void ConfigurePipeline(this WebApplication app)
    {
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains("ready"),
            });

            endpoints.MapHealthChecks("/health/live", new HealthCheckOptions());
        });
    }
    
    private static void AddLogging(IConfiguration configuration)
    {
        string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .Enrich.WithEnvironmentName()
            .Enrich.WithMachineName()
            .WriteTo.Console()
            .WriteTo.Debug()
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(Configuration.AppSetting.ElasticSearch.Uri))
            {
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
                IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name!.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
            })
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
    }
}