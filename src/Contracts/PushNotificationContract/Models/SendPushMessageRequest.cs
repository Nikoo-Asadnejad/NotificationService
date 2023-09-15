using FirebaseAdmin.Messaging;

namespace PushNotificationContract.Models;

public sealed record SendPushMessageRequest
{
    public SendPushMessageRequest(string DeviceToken,string Title , string Message)
    {
        this.DeviceToken = DeviceToken;
        this.Title = Title;
        this.Message = Message;
    }
    public string DeviceToken { get; init; }
    public string Title { get; init; }
    public string Message { get; init; }
    public void Deconstruct(out string DeviceToken, out string Title , out string Message)
    {
        DeviceToken = this.DeviceToken;
        Title = this.Title;
        Message = this.Message;
    }
    
    public static explicit operator Message (SendPushMessageRequest request)
        => new Message()
        {
            Token = request.DeviceToken,
            Notification = new Notification()
            {
                Title = request.Title,
                Body = request.Message
            }
        };
}

