using MassTransit;
using SmsService.Enums;
using SmsService.Interfaces;
using SmsService.Services;

namespace SmsService.Configurations;

public static class SmsConfigurator
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
        services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq();
        });
    }

    public static void ConfigurePipeline(this WebApplication app)
    {
        app.UseAuthorization();
        app.Run();
    }
}