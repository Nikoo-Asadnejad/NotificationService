using ResponseBase.Dtos;
using SmsService.Dtos;

namespace SmsService.Interfaces;

public interface ISmsService
{
    Task<ResponseBase<SendSmsResponse>> SendSmsAsync(SendSmsRequest request);
}