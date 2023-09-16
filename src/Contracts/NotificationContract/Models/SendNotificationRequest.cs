using EmailContract.Models;
using NotificationContract.Enums;
using PushNotificationContract.Models;
using SmsContract.Models;

namespace NotificationContract.Models;

public sealed record SendNotificationRequest
{
    public required NotificationType[] NotificationTypes { get; set; }
    public string? Title { get;  set; }
    public string? ReceptorName { get;  set; }
    public  string Message { get;  set;}
    public string? Email { get; set;}
    public string? PhoneNumber { get; set; }
    public string? DeviceToken { get; set;}
    
    public static explicit operator SendEmailRequest(SendNotificationRequest notification)
    {
        if (!notification.NotificationTypes.Contains(NotificationType.Email))
            throw new Exception("This type can't be converted to emailRequest");
        
        ArgumentNullException.ThrowIfNullOrEmpty(notification.Email);
        ArgumentNullException.ThrowIfNullOrEmpty(notification.Message);
        ArgumentNullException.ThrowIfNullOrEmpty(notification.ReceptorName);
        ArgumentNullException.ThrowIfNullOrEmpty(notification.Title);

        SendEmailRequest emailRequest = new(notification.Email,notification.ReceptorName, notification.Title, notification.Message);
        return emailRequest;
    }
    public static explicit operator SendSmsRequest(SendNotificationRequest notification)
    {
        if (!notification.NotificationTypes.Contains(NotificationType.Sms))
            throw new Exception("This type can't be converted to smsRequest");

        ArgumentNullException.ThrowIfNullOrEmpty(notification.PhoneNumber);
        ArgumentNullException.ThrowIfNullOrEmpty(notification.Message);
        
        SendSmsRequest smsRequest = new(notification.PhoneNumber, notification.Message);
        return smsRequest;
    }
    public static explicit operator SendPushMessageRequest(SendNotificationRequest notification)
    {
        if (!notification.NotificationTypes.Contains(NotificationType.PushMessage))
            throw new Exception("This type can't be converted to pushMessageRequest");
        
        ArgumentNullException.ThrowIfNullOrEmpty(notification.DeviceToken);
        ArgumentNullException.ThrowIfNullOrEmpty(notification.Title);
        ArgumentNullException.ThrowIfNullOrEmpty(notification.Message);
        
        SendPushMessageRequest pushMessageRequestRequest = new(notification.DeviceToken, notification.Title,notification.Message);
        return pushMessageRequestRequest;
    }
    
}