using MassTransit;
using SmsService.Interfaces;
using SmsService.Services;
using SmsContract.Enums;
using SmsService.Consumers;

namespace SmsService.Configurations;

public static class Configurator
{
    public static void InjectService(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<ISmsService, Services.SmsService>();
        services.AddTransient<Func<Provider, ISmsProvider>>(servideProvider => provider =>
        provider switch
            {
                Provider.Kavenegar => servideProvider.GetService<KaveNegarProvider>(),
                _ => new KaveNegarProvider(),
            });
        
        configuration.Bind(Configuration.AppSetting);
        
    }

    public static void AddRabbitConsumer(this IServiceCollection services)
    =>services.AddMassTransit(configurator =>
    {
        var rabbitSetting = Configuration.AppSetting.RabbitMqSetting;
        configurator.UsingRabbitMq();
        configurator.AddConsumer<SmsConsumer>();
        configurator.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
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
        app.UseAuthorization();
    }
}