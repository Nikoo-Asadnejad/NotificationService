using ResponseBase.Dtos;
using SmsContract.Models;

namespace SmsService.Interfaces;

public interface ISmsService
{
    Task<ResponseBase<SendSmsResponse>> SendSmsAsync(SendSmsRequest request);
}