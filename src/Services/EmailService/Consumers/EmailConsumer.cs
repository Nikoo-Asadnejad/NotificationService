using EmailContract.Models;
using EmailService.Interfaces;
using MassTransit;

namespace EmailService.Consumers;

public sealed class EmailConsumer : IConsumer<SendEmailRequest>
{
    private readonly IEmailService _emailService;
    public EmailConsumer(IEmailService emailService) : base()
    {
        _emailService = emailService;
    }
    public async Task Consume(ConsumeContext<SendEmailRequest> context)
    {
        if (context is null)
            return;
        await _emailService.SendAsync(context.Message);
    }
}