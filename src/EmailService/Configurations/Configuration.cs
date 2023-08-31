namespace EmailService.Configurations;

public struct Configuration
{
    public static AppSetting AppSetting { get;}
}
public struct AppSetting
{
    public Logging Logging { get; set; }
    public MailSettings MailSettings { get; set; }
    
    public RabbitMqSetting RabbitMqSetting { get; set; }
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

public record MailSettings
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