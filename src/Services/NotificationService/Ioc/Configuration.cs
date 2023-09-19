using MassTransit.Futures.Contracts;

namespace NotificationService.Ioc;

public struct Configuration
{
    public static AppSetting AppSetting { get; private set; }
    public static void SetUp(IConfiguration configuration)
    {
        AppSetting appsetting = new();
        configuration.Bind(appsetting);
        Configuration.AppSetting = appsetting;
    }
}

public class AppSetting
{
    public Logging Logging { get; set; }
    public string AllowedHosts { get; set; }
    public SeriLog SeriLog { get; set; }
    public ElasticSearch ElasticSearch { get; set; }
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
public struct SeriLog
{
    public MinimumLevel MinimumLevel { get; set; }
}
public struct MinimumLevel
{
    public string Default { get; set; }
    public Override Override { get; set; }
}
public struct Override
{
    public string Microsoft { get; set; }
    public string System { get; set; }
}
public struct ElasticSearch 
{
    public string Uri { get; set; }
}

