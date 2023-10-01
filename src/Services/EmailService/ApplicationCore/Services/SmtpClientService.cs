using System.Net.Mail;
using EmailService.Interfaces;

namespace EmailService.Services;

public sealed class SmtpClientService : ISmtpClient
{
    public async Task SendAsync(MailMessage message, CancellationToken calnceleationToke = new CancellationToken())
    {
        SmtpClient smtpClient = new SmtpClient();
        try
        {
            using (smtpClient);
            await smtpClient.SendMailAsync(message, calnceleationToke);
        }
        catch (Exception e)
        {
           smtpClient.Dispose();
        }
       
    }
}