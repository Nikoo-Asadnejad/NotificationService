using FirebaseAdmin.Messaging;
using PushNotificationContract.Models;
using PushNotificationService.Interfaces;


namespace PushNotificationService.Services;

public sealed class PushNotificationService : IPushNotificationService
{
    public async Task SendAsync(SendPushMessageRequest request)
    {
        if (request is null)
            throw new ArgumentNullException();

        if (string.IsNullOrWhiteSpace(request.Message))
            throw new ArgumentException("Message can't be null");

        if (string.IsNullOrWhiteSpace(request.DeviceToken))
            throw new ArgumentException("Device Token can't be null");
        
        Message message = (Message)request;
        await FirebaseMessaging.DefaultInstance.SendAsync(message);
    }
}