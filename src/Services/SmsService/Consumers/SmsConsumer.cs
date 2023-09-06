using MassTransit;
using SmsContract.Models;
using SmsService.Interfaces;

namespace SmsService.Consumers;

public class SmsConsumer : IConsumer<SendSmsRequest>
{
    private readonly ISmsService _smsService;
    public SmsConsumer(ISmsService smsService)
    {
        _smsService = smsService;
    }
    public async Task Consume(ConsumeContext<SendSmsRequest> context )
    {
        await _smsService.SendAsync(context.Message);
    }
}