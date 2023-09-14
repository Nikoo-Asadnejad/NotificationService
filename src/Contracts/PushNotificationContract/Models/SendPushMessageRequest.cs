namespace PushNotificationContract.Models;

public sealed record SendPushMessageRequest(string DeviceToken,string Title , string Message);