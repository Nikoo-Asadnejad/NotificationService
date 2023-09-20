namespace EmailService.Configurations;

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
    public MailSetting MailSettings { get; set; }
    public RabbitMqSetting RabbitMqSetting { get; set; }
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

public record MailSetting
{
    public string Server { get; set; }
    public int Port { get; set; }
    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}

public struct RabbitMqSetting
{
    public  string Url { get; set; }
    public  string UserName { get; set; }
    public  string Password { get; set; }
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


