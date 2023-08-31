using EmailService.Consumers;
using EmailService.Interfaces;
using EmailService.Services;
using MassTransit;

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
        configuration.Bind(Configuration.AppSetting);
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
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}