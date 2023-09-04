using EmailService.Consumers;
using EmailService.Interfaces;
using EmailService.Services;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace EmailService.Configurations;

public static class SmsConfigurator
{
    public static void InjectService(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<IEmailService, EmailSenderService>();
        services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq();
        });

        var appSetting = new AppSetting();
        configuration.Bind(appSetting);
        Configuration.AppSetting = appSetting;
    }
    
    public static void AddRabbitConsumer(this IServiceCollection services)
        =>services.AddMassTransit(configurator =>
        {
            var rabbitSetting = Configuration.AppSetting.RabbitMqSetting;
            configurator.UsingRabbitMq();
            configurator.AddConsumer<EmailConsumer>();
            configurator.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(rabbitSetting.Url), h =>
                {
                    h.Username(rabbitSetting.UserName);
                    h.Password(rabbitSetting.Password);
                });
                cfg.ReceiveEndpoint("emailQueue", ep =>
                {
                    ep.PrefetchCount = 16;
                    ep.Durable = true;
                    ep.UseMessageRetry(r => r.Interval(2, 100));
                    ep.ConfigureConsumer<EmailConsumer>(provider);
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
}