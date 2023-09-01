using MimeKit;

namespace EmailContract.Models;

public record SendEmailRequest(string ReceptorMail,string ReceptorName,string Subject, string Body);