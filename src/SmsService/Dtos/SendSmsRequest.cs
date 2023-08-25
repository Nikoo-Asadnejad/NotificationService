namespace SmsService.Dtos;

public record SendSmsRequest(string message, string receptorPhoneNumber);