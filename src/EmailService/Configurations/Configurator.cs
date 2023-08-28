using EmailService.Interfaces;
using EmailService.Services;

namespace EmailService.Configurations;

public static class SmsConfigurator
{
    public static void InjectService(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<IEmailService, EmailSenderService>();
    }

    public static void ConfigurePipeline(this WebApplication app)
    {
        
    }
}