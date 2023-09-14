using FirebaseAdmin.Messaging;
using PushNotificationContract.Models;

namespace PushNotificationService.Tools;

public static class Mappers
{
    public static Message MapToFireBaseMessage(this SendPushMessageRequest request)
        => new Message()
        {
            Token = request.DeviceToken,
            Notification = new Notification()
            {
                Title = request.Title,
                Body = request.Message
            }
        };
}