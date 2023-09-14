using System.Runtime.CompilerServices;
using EmailContract.Models;
using SmsContract.Models;

namespace NotificationContract.Models;

public record SendNotificationRequest
{
    public string? Title { get; }
    public string? ReceptorName { get;  }
    public  string Message { get; }
    public string? Email { get; }
    public string? PhoneNumber { get;  }
    public string? DeviceToken { get; }

    public static explicit operator SendEmailRequest(SendNotificationRequest notification)
    {
        if (notification.Email is null)
            throw new ArgumentNullException("Email",message:"For sending an email, email field shouldn't be null");
        
        if (notification.Message is null)
            throw new ArgumentNullException("Message",message:"For sending an email, message field shouldn't be null");
        
        if (notification.ReceptorName is null)
            throw new ArgumentNullException("ReceptorName",message:"For sending an email, receptorName field shouldn't be null");
        
        if (notification.Title is null)
            throw new ArgumentNullException("Title",message:"For sending an email, title field shouldn't be null");

        SendEmailRequest emailRequest = new(notification.Email,notification.ReceptorName, notification.Title, notification.Message);
        return emailRequest;
    }

    public static explicit operator SendSmsRequest(SendNotificationRequest notification)
    {
        if (notification.PhoneNumber is null)
            throw new ArgumentNullException("PhoneNumber",message:"For sending an sms, phoneNumber field shouldn't be null");
    
        if (notification.Message is null)
            throw new ArgumentNullException("Message",message:"For sending an sms, message field shouldn't be null");

        SendSmsRequest smsRequest = new(notification.PhoneNumber, notification.Message);
        return smsRequest;
    }

    
}