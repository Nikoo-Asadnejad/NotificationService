using Kavenegar;
using Kavenegar.Core.Exceptions;
using Kavenegar.Core.Models;
using Microsoft.Extensions.Options;
using SmsService.Configurations;
using SmsService.Interfaces;
using SmsContract.Enums;
using SmsContract.Models;

namespace SmsService.Services;

public sealed class KaveNegarProvider : ISmsProvider
{
    private KavenegarApi _kaveNegarApi;
    private readonly ProviderSetting _providerSettings;

    public KaveNegarProvider(IOptions<AppSetting> appsettings)
    { 
        _providerSettings = appsettings.Value.Providers.FirstOrDefault(p => p.Type is Provider.Kavenegar);
        _kaveNegarApi = new KavenegarApi(_providerSettings.ApiKey);
    }
    public async Task<SendSmsResponse> SendAsync(SendSmsRequest request)
    {
        try
        {

            SendResult sendSmsResult = await _kaveNegarApi.Send(sender: _providerSettings.SenderUrl,
                receptor: request.ReceptorPhoneNumber,
                message: request.Message);

            return new SendSmsResponse(sendSmsResult.StatusText);
        }
        catch (ApiException ex)
        {
            throw;
            //if the http response of web service is not 200 this exception will rise
            //return (HttpStatusCode.InternalServerError, message: ex.Message);
        }
        catch (HttpException ex)
        {
            throw;
            //if the service is not reachable this exception will rise
            // return (HttpStatusCode.ServiceUnavailable, message: ex.Message);
        }
        catch (Exception ex)
        {
            throw ;
            // return HttpStatusCode.InternalServerError;
        }
    }
}