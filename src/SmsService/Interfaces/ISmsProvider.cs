using ResponseBase.Dtos;
using SmsService.Dtos;

namespace SmsService.Interfaces;

public interface ISmsProvider
{
    Task<ResponseBase<SendSmsResponse>> SendAsync(SendSmsRequest request);
}