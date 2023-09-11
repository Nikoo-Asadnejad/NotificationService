using Kavenegar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using SmsContract.Models;
using SmsService.Configurations;
using SmsService.Tests.TestData;


namespace SmsService.Tests.Services;

public sealed class KavenegarProvider_Tests
{
    private readonly Mock<KavenegarApi> _kavenegarApiMoq;
    public KavenegarProvider_Tests()
    {
        Mock<IOptions<AppSetting>> configMoq = new ();
        _kavenegarApiMoq = new();
        
        
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@$"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.test.json", false, false)
            .AddEnvironmentVariables()
            .Build();

        AppSetting appSetting = new();
        config.Bind(appSetting);
        configMoq.Setup(c=> c.Value).Returns(appSetting);
    }
    
   
}