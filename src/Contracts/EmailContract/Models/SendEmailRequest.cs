using System.Net.Mail;
using System.Net.Mime;

namespace EmailContract.Models;

public sealed record SendEmailRequest(string ReceptorMail, string ReceptorName, string Subject, string Body);