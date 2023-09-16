using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace NotificationService.Ioc;

public static class Configurator
{
    public static void InjectService(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq();
        });

        Configuration.SetUp(configuration);
    }
    
    public static void ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
            {
                Predicate = (check) => check.Tags.Contains("ready"),
            });

            endpoints.MapHealthChecks("/health/live", new HealthCheckOptions());
        });
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

    }
    

}