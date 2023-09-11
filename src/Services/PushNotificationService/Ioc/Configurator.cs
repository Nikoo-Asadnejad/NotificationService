using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace PushNotificationService.Configurations;

public static class SmsConfigurator
{
    public static void InjectService(this IServiceCollection services , IConfiguration configuration)
    {

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