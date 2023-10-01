using System.Net.Mail;

namespace EmailService.Interfaces;

public interface ISmtpClient
{
    Task SendAsync(MailMessage message, CancellationToken calnceleationToke = new());
}