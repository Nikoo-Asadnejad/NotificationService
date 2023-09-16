using MassTransit;
using NotificationContract.Models;
using NotificationService.Interfaces;

namespace NotificationService.Consumers;

public class NotificationConsumer : IConsumer<SendNotificationRequest>
{
    private readonly INotificationService _notificationService;

    public NotificationConsumer(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    public async Task Consume(ConsumeContext<SendNotificationRequest> context)
    {
        await _notificationService.SendAsync(context.Message);
    }
}