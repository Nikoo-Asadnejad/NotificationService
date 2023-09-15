using NotificationContract.Models;
using NotificationContract.Tests.TestData;
using SmsContract.Models;
using Xunit.Sdk;

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
}