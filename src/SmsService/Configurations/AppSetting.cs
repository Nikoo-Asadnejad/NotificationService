using SmsContract.Enums;

namespace SmsService.Configurations;

public class AppSetting
{
    public List<ProviderSetting> Providers { get; set; }
}

public class ProviderSetting
{
    public Provider Type { get; set; }
    public string Name { get; set; }
    public string SenderUrl { get; set; }
    public string ApiKey { get; set; }
}