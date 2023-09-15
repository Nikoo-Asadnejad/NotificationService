using System.Runtime.CompilerServices;
using EmailContract.Models;
using PushNotificationContract.Models;
using SmsContract.Models;

namespace NotificationContract.Models;

public sealed record SendNotificationRequest
{
    public string? Title { get;  set; }
    public string? ReceptorName { get;  set; }
    public  string Message { get;  set;}
    public string? Email { get; set;}
    public string? PhoneNumber { get; set; }
    public string? DeviceToken { get; set;}

    public static explicit operator SendEmailRequest(SendNotificationRequest notification)
    {
        if (string.IsNullOrWhiteSpace(notification.Email))
            throw new ArgumentNullException("Email",message:"For sending an email, email field shouldn't be null");
        
        if (string.IsNullOrWhiteSpace(notification.Message))
            throw new ArgumentNullException("Message",message:"For sending an email, message field shouldn't be null");
        
        if (string.IsNullOrWhiteSpace(notification.ReceptorName))
            throw new ArgumentNullException("ReceptorName",message:"For sending an email, receptorName field shouldn't be null");
        
        if (string.IsNullOrWhiteSpace(notification.Title))
            throw new ArgumentNullException("Title",message:"For sending an email, title field shouldn't be null");

        SendEmailRequest emailRequest = new(notification.Email,notification.ReceptorName, notification.Title, notification.Message);
        return emailRequest;
    }
    public static explicit operator SendSmsRequest(SendNotificationRequest notification)
    {
        if (string.IsNullOrWhiteSpace(notification.PhoneNumber))
            throw new ArgumentNullException("PhoneNumber",message:"For sending a sms, phoneNumber field shouldn't be null");
    
        if (string.IsNullOrWhiteSpace(notification.PhoneNumber))
            throw new ArgumentNullException("Message",message:"For sending a sms, message field shouldn't be null");

        SendSmsRequest smsRequest = new(notification.PhoneNumber, notification.Message);
        return smsRequest;
    }
    public static explicit operator SendPushMessageRequest(SendNotificationRequest notification)
    {
        if (string.IsNullOrWhiteSpace(notification.DeviceToken))
            throw new ArgumentNullException("DeviceToken",message:"For sending a push message, deviceToken field shouldn't be null");
    
        if (string.IsNullOrWhiteSpace(notification.Title))
            throw new ArgumentNullException("Title",message:"For sending a push message, title field shouldn't be null");
        
        if (string.IsNullOrWhiteSpace(notification.Message))
            throw new ArgumentNullException("Message",message:"For sending a push message, message field shouldn't be null");

        SendPushMessageRequest pushMessageRequestRequest = new(notification.DeviceToken, notification.Title,notification.Message);
        return pushMessageRequestRequest;
    }
    
}