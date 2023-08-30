using MassTransit;
using SmsService.Interfaces;
using SmsService.Services;
using SmsContract.Enums;

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
        services.AddMassTransit(configurator =>
        {
            configurator.UsingRabbitMq();
        });
    }

    public static void ConfigurePipeline(this WebApplication app)
    {
        app.UseAuthorization();
    }
}