namespace EmailService.Dtos;

public record SendEmailRequest(string ReceptorMail,string ReceptorName, string Subject,string Body);