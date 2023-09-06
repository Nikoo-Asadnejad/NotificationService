using MassTransit;
using SmsContract.Models;
using SmsService.Interfaces;

namespace SmsService.Consumers;

public sealed class SmsConsumer : IConsumer<SendSmsRequest>
{
    private readonly ISmsService _smsService;
    public SmsConsumer(ISmsService smsService)
    {
        _smsService = smsService;
    }
    public async Task Consume(ConsumeContext<SendSmsRequest> context )
    {
        if(context is null || context.Message is null)
            return;
        
        await _smsService.SendAsync(context.Message);
    }
}