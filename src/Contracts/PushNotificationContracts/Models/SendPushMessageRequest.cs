namespace PushNotificationContracts.Models;

public sealed record SendPushMessageRequest(string DeviceToken,string Title , string Message);