using EmailContract.Models;
using EmailService.ApplicationCore.Mappers;
using EmailService.Configurations;
using EmailService.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;

namespace EmailService.Services;

public sealed class EmailSenderService : IEmailService
{
    private readonly ISmtpClient _smtpClient;
    private readonly MailSetting _mailSetting;
    public EmailSenderService(ISmtpClient smtpClient , IOptions<AppSetting> config)
    {
        _smtpClient = smtpClient;
        _mailSetting = config.Value.MailSettings;
    }

    public async Task SendAsync(SendEmailRequest message)
    {
        if (message is null)
            throw new ArgumentNullException(nameof(message));

        if (string.IsNullOrWhiteSpace(message.ReceptorMail))
            throw new ArgumentException("ReceptorMail can't be null");

        if (string.IsNullOrWhiteSpace(message.Body))
            throw new ArgumentException("Body can't be null");

        await _smtpClient.SendAsync(message.MapToMailMessage());
    }



  
}