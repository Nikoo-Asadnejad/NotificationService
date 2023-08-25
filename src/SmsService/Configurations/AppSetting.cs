namespace SmsService.Configurations;

public class AppSetting
{
    public List<Provider> Providers { get; set; }
}

public class Provider
{
    public string Name { get; set; }
    public string SenderUrl { get; set; }
    
    public string ApiKey { get; set; }
}