using PushNotificationContract.Models;

namespace PushNotificationContract.Tests.TestData;

public static class TestDataGenerator
{
    public static SendPushMessageRequest CreateSampleRequest()
        => new SendPushMessageRequest("jndkjvnf", "test","test");
}