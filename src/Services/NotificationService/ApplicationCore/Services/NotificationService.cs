using EmailContract.Models;
using MassTransit;
using NotificationContract.Enums;
using NotificationContract.Models;
using NotificationService.Interfaces;
using PushNotificationContract.Models;
using SmsContract.Models;

namespace NotificationService.Services;

public sealed class NotificationService : INotificationService
{
    private readonly IPublishEndpoint _publishEndpoint;


    public NotificationService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }
    public async Task SendAsync(SendNotificationRequest request)
    {
        Task sendEmail = _publishEndpoint.Publish<SendEmailRequest>(request);
        Task sendSms =  _publishEndpoint.Publish<SendSmsRequest>(request);
        Task sendPushMessage =  _publishEndpoint.Publish<SendPushMessageRequest>(request);

        List<Task> tasks = new() ;
        
        if(request.NotificationTypes.Contains(NotificationType.Email))
            tasks.Add(sendEmail);
        if(request.NotificationTypes.Contains(NotificationType.Sms))
            tasks.Add(sendSms);
        if(request.NotificationTypes.Contains(NotificationType.PushMessage))
            tasks.Add(sendPushMessage);

        await Task.WhenAll(tasks);
    }
}