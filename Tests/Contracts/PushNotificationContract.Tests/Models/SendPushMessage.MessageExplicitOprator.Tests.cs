using FirebaseAdmin.Messaging;
using PushNotificationContract.Models;
using PushNotificationContract.Tests.TestData;

namespace PushNotificationContract.Tests.Models;

public sealed class SendPushMessage_MessageExplicitOprator_Tests
{
    [Fact]
    public async Task ConvertToFirebaseMessage_OnConvert_FirebaseMessageShouldBeFilledWithSameValues()
    {
        SendPushMessageRequest sendPushMessageRequest = TestDataGenerator.CreateSampleRequest();

        Message firebaseMessage = (Message)sendPushMessageRequest;
        
        Assert.Equal(sendPushMessageRequest.Message , firebaseMessage.Notification.Body);
        Assert.Equal(sendPushMessageRequest.Title , firebaseMessage.Notification.Title);
        Assert.Equal(sendPushMessageRequest.DeviceToken , firebaseMessage.Token);
    }
}