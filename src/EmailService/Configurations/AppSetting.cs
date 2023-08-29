namespace EmailService.Configurations;

public  record AppSetting
{
    public Logging Logging { get; set; }
    public MailSettings MailSettings { get; set; }
}

public record Logging
{
    public LogLevel LogLevel { get; set; }
}

public record LogLevel
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

