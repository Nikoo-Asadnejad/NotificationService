using EmailContract.Models;

namespace EmailService.Tests.TestData;

public static class TestDataGenerator
{
    public static SendEmailRequest CreateSampleRequest()
        => new SendEmailRequest("test@gmail.com","test","testSubject","testBody");
    public static IEnumerable<object[]> GetEmailRequestWithNullReceptors()
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
    public static IEnumerable<object[]> GetEmailRequestWithNullBody()
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