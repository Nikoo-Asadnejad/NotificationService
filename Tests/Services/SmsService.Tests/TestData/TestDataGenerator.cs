using SmsContract.Enums;
using SmsContract.Models;

namespace SmsService.Tests.TestData;

public static class TestDataGenerator
{
    public static SendSmsRequest CreateSampleRequest()
        => new SendSmsRequest(Provider.Kavenegar,"test","09393701422");
    
    public static SendSmsRequest CreateUnvalidProviderRequest()
        => new SendSmsRequest((Provider)200,"test","09393701422");
    public static IEnumerable<object[]> GetSmsRequestWithNullReceptors()
    {

        yield return new object[]
        {
            new SendSmsRequest(Provider.Kavenegar, "test", ""),
        };
        yield return new object[]
        {
            new SendSmsRequest(Provider.Kavenegar, "test", " "),
        };
        yield return new object[]
        {
            new SendSmsRequest(Provider.Kavenegar, "test", null),
        };
        
    }
    public static IEnumerable<object[]> GetSmsRequestWithNullMessage()
    {

        yield return new object[]
        {
            new SendSmsRequest(Provider.Kavenegar, "", "09393701422"),
        };
        yield return new object[]
        {
            new SendSmsRequest(Provider.Kavenegar, " ", "09393701422"),
        };
        yield return new object[]
        {
            new SendSmsRequest(Provider.Kavenegar, null, "09393701422"),
        };

    }
    
}