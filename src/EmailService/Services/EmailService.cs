using EmailService.Configurations;
using EmailService.Dtos;
using EmailService.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailService.Services;

public sealed class EmailSenderService : IEmailService
{
    public async Task SendAsync(SendEmailRequest message)
    {
        var emailMessage = CreateEmailMessage(message);
        Send(emailMessage);
    }

    private MimeMessage CreateEmailMessage(SendEmailRequest message)
    {
        MimeMessage emailMessage = new();
        emailMessage.From.Add(new MailboxAddress(name:Configuration.AppSetting.MailSettings.SenderName,Configuration.AppSetting.MailSettings.SenderEmail));
        emailMessage.To.Add(new MailboxAddress(name:message.ReceptorName , message.ReceptorMail));
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Body };
        return emailMessage;
    }

    private void Send(MimeMessage mailMessage)
    {
        using (var client = new SmtpClient()) 

            try
            {
                client.Connect(Configuration.AppSetting.MailSettings.Server, Configuration.AppSetting.MailSettings.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(Configuration.AppSetting.MailSettings.UserName,
                    Configuration.AppSetting.MailSettings.Password);
                client.Send(mailMessage);
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
    }
}