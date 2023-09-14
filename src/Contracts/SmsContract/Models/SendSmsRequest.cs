using SmsContract.Enums;

namespace SmsContract.Models;

public sealed record SendSmsRequest(string ReceptorPhoneNumber, string Message ,Provider? Provider = Provider.Kavenegar);