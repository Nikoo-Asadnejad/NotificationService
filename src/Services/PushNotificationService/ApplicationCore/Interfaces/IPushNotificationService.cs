using PushNotificationContract.Models;

namespace PushNotificationService.Interfaces;

public interface IPushNotificationService
{
    Task SendAsync(SendPushMessageRequest request);
}