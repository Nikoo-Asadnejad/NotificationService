using PushNotificationContracts.Models;

namespace PushNotificationService.Interfaces;

public interface IPushNotificationService
{
    Task SendAsync(SendPushMessageRequest request);
}