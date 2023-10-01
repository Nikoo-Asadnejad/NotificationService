using System.Net.Mail;
using System.Net.Mime;
using EmailContract.Models;
using EmailService.Configurations;

namespace EmailService.ApplicationCore.Mappers;

public static class RequestMapper
{
    public static MailMessage MapToMailMessage(this SendEmailRequest emailRequest)
        => new MailMessage(from:Configuration.AppSetting.MailSettings.SenderEmail,
                          to: emailRequest.ReceptorMail,
                          subject: emailRequest.Subject,
                          body: emailRequest.Body);
}