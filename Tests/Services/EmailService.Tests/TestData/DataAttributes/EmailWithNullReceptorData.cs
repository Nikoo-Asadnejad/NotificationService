using System.Reflection;
using EmailContract.Models;
using Xunit.Sdk;

namespace EmailService.Tests.TestData;

public sealed class EmailWithNullReceptorData : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[]
        {
            new SendEmailRequest("", "nikoo", "test", "body"),
        };
        yield return new object[]
        {
            new SendEmailRequest(" ", "nikoo", "test", "body"),
        };
        yield return new object[]
        {
            new SendEmailRequest(null, "nikoo", "test", "body"),
        };
    }
}