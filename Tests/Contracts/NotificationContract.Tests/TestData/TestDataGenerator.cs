using NotificationContract.Models;

namespace NotificationContract.Tests.TestData;

public static class TestDataGenerator
{
    public static IEnumerable<object[]> GetRequestsWithNullTitle()
    {
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = null,
                DeviceToken = "jkndkhcbsd",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "",
                DeviceToken = "jkndkhcbsd",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = " ",
                DeviceToken = "jkndkhcbsd",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
    }

    public static IEnumerable<object[]> GetRequestsWithNullDeviceToken()
    {
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = null,
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = " ",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
    }

    public static IEnumerable<object[]> GetRequestsWithNullEmail()
    {
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = null,
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "  ",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
    }

    public static IEnumerable<object[]> GetRequestsWithNullMessage()
    {
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "nikoo@gmail.com",
                Message = null,
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "nikoo@gmail.com",
                Message = "",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "nikoo@gmail.com",
                Message = " ",
                PhoneNumber = "09353409877",
                ReceptorName = "nikoo"
            }
        };
    }

    public static IEnumerable<object[]> GetRequestsWithNullPhoneNumber()
    {
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = null,
                ReceptorName = "nikoo"
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = "",
                ReceptorName = "nikoo"
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = " ",
                ReceptorName = "nikoo"
            }
        };
    }

    public static IEnumerable<object[]> GetRequestsWithNullReceptorName()
    {
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = null
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = ""
            }
        };
        yield return new object[]
        {
            new SendNotificationRequest()
            {
                Title = "test",
                DeviceToken = "jdnhknshc",
                Email = "nikoo@gmail.com",
                Message = "test",
                PhoneNumber = "09353409877",
                ReceptorName = " "
            }
        };
    }
}