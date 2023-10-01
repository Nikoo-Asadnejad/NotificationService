using EmailContract.Models;

namespace EmailService.Tests.TestData;

public static class TestDataGenerator
{
    public static SendEmailRequest CreateSampleRequest()
        => new SendEmailRequest("test@gmail.com","test","testSubject","testBody");
 
 
}