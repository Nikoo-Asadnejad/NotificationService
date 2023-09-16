using MassTransit.Futures.Contracts;

namespace NotificationService.Ioc;

public struct Configuration
{
    public AppSetting AppSetting { get; private set; }
    public void SetUp(IConfiguration configuration)
    {
        AppSetting appsetting = new();
        configuration.Bind(appsetting);
        this.AppSetting = appsetting;
    }
}

public class AppSetting
{
    public Logging Logging { get; set; }
    public string AllowedHosts { get; set; }
}
public struct Logging
{
    public LogLevel LogLevel { get; set; }
}
public struct LogLevel
{
    public string Default { get; set; }
    public string Microsoft_AspNetCore { get; set; }
}

