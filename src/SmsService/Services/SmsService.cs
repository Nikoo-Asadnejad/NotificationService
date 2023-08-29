using ResponseBase.Dtos;
using SmsService.Dtos;
using SmsService.Enums;
using SmsService.Interfaces;

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