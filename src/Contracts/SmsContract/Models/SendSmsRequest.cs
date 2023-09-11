using SmsContract.Enums;

namespace SmsContract.Models;

public sealed record SendSmsRequest(Provider Provider, string message, string receptorPhoneNumber);