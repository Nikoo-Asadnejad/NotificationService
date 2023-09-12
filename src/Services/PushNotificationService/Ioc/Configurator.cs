using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace PushNotificationService.Configurations;

public static class SmsConfigurator
{
    public static void InjectService(this IServiceCollection services , IConfiguration configuration)
    {
        configuration.Bind(Configuration.AppSetting);
        services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq();
        });
        
        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("firebase.json")
        });
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