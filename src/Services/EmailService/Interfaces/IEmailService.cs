using EmailContract.Models;

namespace EmailService.Interfaces;

public interface IEmailService
{
    Task SendAsync(SendEmailRequest request);
}