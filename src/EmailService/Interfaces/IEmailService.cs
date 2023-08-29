using EmailService.Dtos;

namespace EmailService.Interfaces;

public interface IEmailService
{
    Task SendAsync(SendEmailRequest request);
}