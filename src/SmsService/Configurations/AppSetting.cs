using SmsContract.Enums;

namespace SmsService.Configurations;

public struct AppSetting
{
    public List<ProviderSetting> Providers { get; set; }
    public  RabbitMqSetting RabbitMqSetting { get; set; }
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