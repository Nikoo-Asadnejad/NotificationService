using SmsService.Interfaces;
using SmsContract.Enums;
using SmsContract.Models;

namespace SmsService.Services;

public sealed class SendSmsService : ISmsService
{
    public Func<Provider, ISmsProvider> _provider;
    public SendSmsService(Func<Provider, ISmsProvider> provider)
    {
        _provider = provider;
    }

    public async Task<SendSmsResponse> SendAsync(SendSmsRequest request)
    {
        if (request is null)
            throw new ArgumentNullException();

        if (string.IsNullOrWhiteSpace(request.receptorPhoneNumber))
            throw new ArgumentException("Receptor phone number cannot be null");
            
        if(string.IsNullOrWhiteSpace(request.message))
            throw new ArgumentException("Message cannot be null");
        
        return request.Provider switch
        {
            Provider.Kavenegar => await _provider(Provider.Kavenegar).SendAsync(request),
            _ => throw new Exception("Provider is not valid"),
        };
    }
 
}