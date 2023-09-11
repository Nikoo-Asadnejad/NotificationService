namespace PushNotificationContracts.Models;

public sealed record SendPushMessageRequest(string Title , string Message, string DeviceToken);