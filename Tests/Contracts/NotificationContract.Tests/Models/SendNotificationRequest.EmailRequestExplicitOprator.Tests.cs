using EmailContract.Models;
using NotificationContract.Models;
using NotificationContract.Tests.TestData;
using SmsContract.Models;
using Xunit.Sdk;

namespace NotificationContract.Tests.Models;

public sealed class SendNotificationRequest_EmailRequestExplicitOprator_Tests
{
    [Theory]
    [MemberData(nameof(TestDataGenerator.GetRequestsWithNullEmail), MemberType = typeof(TestDataGenerator))]
    public async Task ConvertToSendEmailRequest_EmailIsNull_ThrowsArgumentNullException(SendNotificationRequest request)
    {
        Func<SendEmailRequest> convertFunc = () => (SendEmailRequest)request;
        var exception = Assert.Throws<ArgumentNullException>(convertFunc);
        Assert.Contains("Email", exception.Message);
    }

    [Theory]
    [MemberData(nameof(TestDataGenerator.GetRequestsWithNullMessage), MemberType = typeof(TestDataGenerator))]
    public async Task ConvertToSendEmailRequest_MessageIsNull_ThrowsArgumentNullException(SendNotificationRequest request)
    {
        Func<SendEmailRequest> convertFunc = () => (SendEmailRequest)request;
        var exception = Assert.Throws<ArgumentNullException>(convertFunc);
        Assert.Contains("Message", exception.Message);
    }

    [Theory]
    [MemberData(nameof(TestDataGenerator.GetRequestsWithNullReceptorName), MemberType = typeof(TestDataGenerator))]
    public async Task ConvertToSendEmailRequest_ReceptorNameIsNull_ThrowsArgumentNullException(
        SendNotificationRequest request)
    {
        Func<SendEmailRequest> convertFunc = () => (SendEmailRequest)request;
        var exception = Assert.Throws<ArgumentNullException>(convertFunc);
        Assert.Contains("ReceptorName", exception.Message);
    }

    [Theory]
    [MemberData(nameof(TestDataGenerator.GetRequestsWithNullTitle), MemberType = typeof(TestDataGenerator))]
    public async Task ConvertToSendEmailRequest_TitleIsNull_ThrowsArgumentNullException(SendNotificationRequest request)
    {
        Func<SendEmailRequest> convertFunc = () => (SendEmailRequest)request;
        var exception = Assert.Throws<ArgumentNullException>(convertFunc);
        Assert.Contains("Title", exception.Message);
    }

    [Fact]
    public async Task ConvertToSendEmailRequest_OnConvert_SendEmailRequestShouldBeFilledWithNotificationValues()
    {
        SendNotificationRequest notificationRequest = TestDataGenerator.CreateSampleRequest();

        SendEmailRequest emailRequest = (SendEmailRequest)notificationRequest;

        Assert.Equal(notificationRequest.Email , emailRequest.ReceptorMail);
        Assert.Equal(notificationRequest.ReceptorName , emailRequest.ReceptorName);
        Assert.Equal(notificationRequest.Message , emailRequest.Body);
        Assert.Equal(notificationRequest.Title , emailRequest.Subject);
    }
}
    