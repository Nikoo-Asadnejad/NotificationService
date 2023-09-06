using SmsContract.Models;

namespace SmsService.Interfaces;

public interface ISmsProvider
{
    Task<SendSmsResponse> SendAsync(SendSmsRequest request);
}