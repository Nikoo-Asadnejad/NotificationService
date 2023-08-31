using MassTransit;
using SmsContract.Models;

namespace SmsService.Consumers;

public class SmsConsumer : IConsumer<SendSmsRequest>
{
    
    public Task Consume(ConsumeContext<SendSmsRequest> context )
    {
        throw new NotImplementedException();
    }
}