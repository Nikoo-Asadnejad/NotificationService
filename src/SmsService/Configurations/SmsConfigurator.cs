using System.Runtime.InteropServices.ComTypes;
using SmsService.Enums;
using SmsService.Interfaces;
using SmsService.Services;

namespace SmsService.Configurations;

public static class SmsConfigurator
{
    public static void InjectService(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddScoped<ISmsService, Services.SmsService>();
        services.AddTransient<Func<Provider, ISmsProvider>>(servidepProvider => provider =>
        {
             switch(provider)
            {
                case Provider.Kavenegar :
                    return servidepProvider.GetService<KaveNegarProvider>();
                default :
                return servidepProvider.GetService<KaveNegarProvider>();
            };
        });
        
        configuration.Bind(Configuration.AppSetting);
    }
}