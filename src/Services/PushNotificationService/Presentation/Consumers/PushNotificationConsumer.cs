using MassTransit;
using PushNotificationContract.Models;
using PushNotificationService.Interfaces;

namespace PushNotificationService.Consumers;

public class PushNotificationConsumer : IConsumer<SendPushMessageRequest>
{
    private readonly IPushNotificationService _pushNotificationService;
    public PushNotificationConsumer(IPushNotificationService pushNotificationService)
    {
        _pushNotificationService = pushNotificationService;
    }
    public async Task Consume(ConsumeContext<SendPushMessageRequest> context)
    {
        await  _pushNotificationService.SendAsync(context.Message);
    }
}