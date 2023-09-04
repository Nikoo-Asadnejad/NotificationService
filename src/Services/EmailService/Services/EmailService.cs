using EmailContract.Models;
using EmailService.Configurations;
using EmailService.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailService.Services;

public sealed class EmailSenderService : IEmailService
{
    private readonly ISmtpClient _smtpClient;
    private readonly MailSetting _mailSetting;
    public EmailSenderService(ISmtpClient smtpClient)
    {
        _smtpClient = smtpClient;
        _mailSetting = Configuration.AppSetting.MailSettings;
    }

    public async Task SendAsync(SendEmailRequest message)
    {
        if (message is null)
            throw new ArgumentNullException("message");

        if (string.IsNullOrWhiteSpace(message.ReceptorMail))
            throw new ArgumentException("ReceptorMail can't be null");

        if (string.IsNullOrWhiteSpace(message.Body))
            throw new ArgumentException("Body can't be null");

        var emailMessage = CreateEmailMessage(message);
        Send(emailMessage);
    }

    private MimeMessage CreateEmailMessage(SendEmailRequest message)
    {
        MimeMessage emailMessage = new();
        emailMessage.From.Add(new MailboxAddress(name: _mailSetting.SenderName, _mailSetting.SenderEmail));
        emailMessage.To.Add(new MailboxAddress(name: message.ReceptorName, message.ReceptorMail));
        emailMessage.Subject = message.Subject;
        emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Body };
        return emailMessage;
    }

    private void Send(MimeMessage mailMessage , CancellationToken cancellationToken = new CancellationToken())
    {
        using (_smtpClient)

            try
            {
                _smtpClient.Connect(_mailSetting.Server,_mailSetting.Port, true, cancellationToken);
                _smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                _smtpClient.Authenticate(_mailSetting.UserName,_mailSetting.Password,cancellationToken);
                _smtpClient.Send(mailMessage,cancellationToken);
            }
            catch
            {
                //log an error message or throw an exception or both.
                throw;
            }
            finally
            {
                _smtpClient.Disconnect(true);
                _smtpClient.Dispose();
            }
    }
}