using EmailContract.Models;
using NotificationContract.Models;
using NotificationContract.Tests.TestData;
using PushNotificationContract.Models;
using SmsContract.Models;
using Xunit.Sdk;

namespace NotificationContract.Tests.Models;

public sealed class SendNotificationRequest_PushMessageRequestExplicitOprator_Tests
{
   
    
    [Theory]
    [MemberData(nameof(TestDataGenerator.GetRequestsWithNullMessage),MemberType = typeof(TestDataGenerator))]
    public async Task ConvertToSendSmsRequest_MessageIsNull_ThrowsArgumentNullException(SendNotificationRequest request)
    {
        Func<SendPushMessageRequest> convertFunc = () => (SendPushMessageRequest)request;
        Exception exception = Assert.Throws<ArgumentNullException>(convertFunc);
        Assert.Contains("Message" ,exception.Message);
    }
    
    [Theory]
    [MemberData(nameof(TestDataGenerator.GetRequestsWithNullTitle),MemberType = typeof(TestDataGenerator))]
    public async Task ConvertToSendSmsRequest_TitleIsNull_ThrowsArgumentNullException(SendNotificationRequest request)
    {
        Func<SendPushMessageRequest> convertFunc = () => (SendPushMessageRequest)request;
        Exception exception = Assert.Throws<ArgumentNullException>(convertFunc);
        Assert.Contains("Title" ,exception.Message);
    }
    
    [Theory]
    [MemberData(nameof(TestDataGenerator.GetRequestsWithNullDeviceToken),MemberType = typeof(TestDataGenerator))]
    public async Task ConvertToSendSmsRequest_DeviceTokenIsNull_ThrowsArgumentNullException(SendNotificationRequest request)
    {
        Func<SendPushMessageRequest> convertFunc = () => (SendPushMessageRequest)request;
        Exception exception = Assert.Throws<ArgumentNullException>(convertFunc);
        Assert.Contains("DeviceToken" ,exception.Message);
    }
}