using System.Reflection;
using EmailContract.Models;
using Xunit.Sdk;

namespace EmailService.Tests.TestData;

public class EmailRequestWithNullBodyData : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        yield return new object[]
        {
            new SendEmailRequest("nikooasadnejad.work@gmail.com", "nikoo", "test", ""),
        };
        yield return new object[]
        {
            new SendEmailRequest("nikooasadnejad.work@gmail.com", "nikoo", "test", " "),
        };
        yield return new object[]
        {
            new SendEmailRequest("nikooasadnejad.work@gmail.com", "nikoo", "test", null),
        };
    }
}