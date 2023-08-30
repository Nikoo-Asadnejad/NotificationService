using SmsContract.Enums;

namespace SmsContract.Models;

public record SendSmsRequest(Provider Provider, string message, string receptorPhoneNumber);