using EmailService.Dtos;
using EmailService.Interfaces;

namespace EmailService.Services;

public sealed class EmailSenderService : IEmailService
{
    public Task SendAsync(SendEmailRequest request)
    {
        throw new NotImplementedException();
    }
}