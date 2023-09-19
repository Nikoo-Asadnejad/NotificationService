using SmsContract.Enums;

namespace SmsService.Configurations;

public struct Configuration
{
    public static AppSetting AppSetting { get; set; }
}

public class AppSetting
{
    public Logging Logging { get; set; }
    public List<ProviderSetting> Providers { get; set; }
    public  RabbitMqSetting RabbitMqSetting { get; set; }
    public SeriLog SeriLog { get; set; }
    public ElasticSearch ElasticSearch { get; set; }
}

public struct ProviderSetting
{
    public Provider Type { get; set; }
    public string Name { get; set; }
    public string SenderUrl { get; set; }
    public string ApiKey { get; set; }
}

public struct RabbitMqSetting
{
    public  string Url { get; set; }
    public  string UserName { get; set; }
    public  string Password { get; set; }
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