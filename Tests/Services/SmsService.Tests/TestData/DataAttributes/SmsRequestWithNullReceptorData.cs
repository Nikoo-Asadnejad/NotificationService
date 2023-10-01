using System.Reflection;
using SmsContract.Models;
using Xunit.Sdk;

namespace SmsService.Tests.TestData.DataAttributes;

public sealed class SmsRequestWithNullReceptorData : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
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
}