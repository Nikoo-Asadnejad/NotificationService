using SmsService.Enums;

namespace SmsService.Dtos;

public record SendSmsRequest(Provider Provider, string message, string receptorPhoneNumber);