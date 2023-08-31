using ResponseBase.Dtos;
using SmsService.Interfaces;
using SmsContract.Enums;
using SmsContract.Models;

namespace SmsService.Services;

public sealed class SmsService : ISmsService
{
    public Func<Provider, ISmsProvider> _provider;
    public SmsService(Func<Provider, ISmsProvider> provider)
    {
        _provider = provider;
    }
    public async Task<ResponseBase<SendSmsResponse>> SendSmsAsync(SendSmsRequest request)
    => request.Provider switch
        {
            Provider.Kavenegar => await _provider(Provider.Kavenegar).SendAsync(request),
            _ => throw new Exception("Provider is not valid"),
        };
 
}