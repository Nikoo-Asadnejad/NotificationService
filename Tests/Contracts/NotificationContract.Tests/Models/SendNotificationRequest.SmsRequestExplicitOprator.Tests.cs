using NotificationContract.Models;
using NotificationContract.Tests.TestData;
using SmsContract.Models;

namespace NotificationContract.Tests.Models;

public sealed class SendNotificationRequest_SmsRequestExplicitOprator_Tests
{
    [Theory]
    [MemberData(nameof(TestDataGenerator.GetRequestsWithNullPhoneNumber),MemberType = typeof(TestDataGenerator))]
    public async Task ConvertToSendSmsRequest_PhoneNumberIsNull_ThrowsArgumentNullException(SendNotificationRequest request)
    {
        Func<SendSmsRequest> convertFunc = () => (SendSmsRequest)request;
        var exception = Assert.Throws<ArgumentNullException>(convertFunc);
        Assert.Contains("phoneNumber" ,exception.Message);
    }
    
    [Theory]
    [MemberData(nameof(TestDataGenerator.GetRequestsWithNullMessage),MemberType = typeof(TestDataGenerator))]
    public async Task ConvertToSendSmsRequest_MessageIsNull_ThrowsArgumentNullException(SendNotificationRequest request)
    {
        Func<SendSmsRequest> convertFunc = () => (SendSmsRequest)request;
        var exception = Assert.Throws<ArgumentNullException>(convertFunc);
        Assert.Contains("message" ,exception.Message);
    }
    
    [Fact]
    public async Task ConvertToSendSmsRequest_OnConvert_SendSmsRequestShouldBeFilledWithNotificationValues()
    {
        SendNotificationRequest notificationRequest = TestDataGenerator.CreateSampleRequest();

        SendSmsRequest sendSmsRequest = (SendSmsRequest)notificationRequest;
        
        Assert.Equal(notificationRequest.Message , sendSmsRequest.Message);
        Assert.Equal(notificationRequest.PhoneNumber , sendSmsRequest.ReceptorPhoneNumber);
    }
}