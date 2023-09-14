using SmsContract.Enums;
using SmsContract.Models;

namespace SmsService.Tests.TestData;

public static class TestDataGenerator
{
    public static SendSmsRequest CreateSampleRequest()
        => new SendSmsRequest("09393701422","test");
    
    public static SendSmsRequest CreateUnvalidProviderRequest()
        => new SendSmsRequest("09393701422","test", (Provider)200);
    public static IEnumerable<object[]> GetSmsRequestWithNullReceptors()
    {

        yield return new object[]
        {
            new SendSmsRequest("", "test"),
        };
        yield return new object[]
        {
            new SendSmsRequest(" ", "test"),
        };
        yield return new object[]
        {
            new SendSmsRequest(null, "test"),
        };
        
    }
    public static IEnumerable<object[]> GetSmsRequestWithNullMessage()
    {

        yield return new object[]
        {
            new SendSmsRequest( "09393701422", ""),
        };
        yield return new object[]
        {
            new SendSmsRequest( "09393701422", " "),
        };
        yield return new object[]
        {
            new SendSmsRequest( "09393701422", null),
        };

    }
    
}