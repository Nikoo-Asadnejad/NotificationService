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

    public static void ConfigurePipeline(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}