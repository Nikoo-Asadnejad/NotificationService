using System.Net;
using Kavenegar;
using Kavenegar.Core.Exceptions;
using Kavenegar.Core.Models;
using Microsoft.Extensions.Options;
using ResponseBase.Dtos;
using SmsService.Configurations;
using SmsService.Dtos;
using SmsService.Enums;
using SmsService.Interfaces;

namespace SmsService.Services;

public class KaveNegarProvider : ISmsProvider
{
    private KavenegarApi _kaveNegarApi;
    private readonly ProviderSetting _providerSettings;

    public KaveNegarProvider()
    { 
        _providerSettings = Configuration.AppSetting.Providers.FirstOrDefault(p => p.Type is Provider.Kavenegar);
        _kaveNegarApi = new KavenegarApi(_providerSettings.ApiKey);
    }
    public async Task<ResponseBase<SendSmsResponse>> SendAsync(SendSmsRequest request)
    {
        try
        {
            SendResult sendSmsResult = await _kaveNegarApi.Send(sender: _providerSettings.SenderUrl,
                receptor: request.receptorPhoneNumber,
                message: request.message);

            return (HttpStatusCode.OK, new SendSmsResponse(sendSmsResult.StatusText));
        }
        catch (ApiException ex)
        {
            //if the http response of web service is not 200 this exception will rise
            return (HttpStatusCode.InternalServerError, message: ex.Message);
        }
        catch (HttpException ex)
        {
            //if the service is not reachable this exception will rise
            return (HttpStatusCode.ServiceUnavailable, message: ex.Message);
        }
        catch (Exception ex)
        {
            return HttpStatusCode.InternalServerError;
        }
    }
}