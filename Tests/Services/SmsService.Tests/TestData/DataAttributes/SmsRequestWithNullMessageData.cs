using System.Reflection;
using SmsContract.Models;
using Xunit.Sdk;

namespace SmsService.Tests.TestData.DataAttributes;

public sealed class SmsRequestWithNullMessageData : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[]
        {
            new SendSmsRequest("09393701422", ""),
        };
        yield return new object[]
        {
            new SendSmsRequest("09393701422", " "),
        };
        yield return new object[]
        {
            new SendSmsRequest("09393701422", null),
        };
    }
}