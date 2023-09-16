using NotificationContract.Models;
using NotificationService.Interfaces;

namespace NotificationService.Services;

public sealed class NotificationService : INotificationService
{
    public Task SendAsync(SendNotificationRequest request)
    {
        throw new NotImplementedException();
    }
}