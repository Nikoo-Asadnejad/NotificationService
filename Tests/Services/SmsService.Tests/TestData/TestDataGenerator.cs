using SmsContract.Enums;
using SmsContract.Models;

namespace SmsService.Tests.TestData;

public static class TestDataGenerator
{
    public static SendSmsRequest CreateSampleRequest()
        => new SendSmsRequest("09393701422","test");
    
    public static SendSmsRequest CreateUnvalidProviderRequest()
        => new SendSmsRequest("09393701422","test", (Provider)200);

  
    
}