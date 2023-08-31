using ResponseBase.Dtos;
using SmsContract.Models;

namespace SmsService.Interfaces;

public interface ISmsProvider
{
    Task<ResponseBase<SendSmsResponse>> SendAsync(SendSmsRequest request);
}