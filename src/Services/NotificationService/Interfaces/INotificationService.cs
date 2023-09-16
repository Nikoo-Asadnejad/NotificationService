using NotificationContract.Models;

namespace NotificationService.Interfaces;

public interface INotificationService
{
    public Task SendAsync(SendNotificationRequest request);
}