using SmsContract.Models;

namespace SmsService.Interfaces;

public interface ISmsService
{
    Task<SendSmsResponse> SendAsync(SendSmsRequest request);
}