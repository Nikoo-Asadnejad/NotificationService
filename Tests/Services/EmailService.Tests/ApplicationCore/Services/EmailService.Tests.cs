using EmailContract.Models;
using EmailService.Configurations;
using EmailService.Interfaces;
using EmailService.Services;
using EmailService.Tests.TestData;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using Moq;

namespace EmailService.Tests.Services;

public sealed class EmailService_Tests
{
    private readonly IEmailService _emailService;
    private readonly Mock<ISmtpClient> _smtpClientMoq;
    private readonly MailSetting _mailSettings;

    public EmailService_Tests()
    {
        _smtpClientMoq = new Mock<ISmtpClient>();
        Mock<IOptions<AppSetting>> configMoq = new Mock<IOptions<AppSetting>>();
        
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@$"appsettings{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.test.json", false, false)
            .AddEnvironmentVariables()
            .Build();

        AppSetting appSetting = new();
        config.Bind(appSetting);
        configMoq.Setup(c=> c.Value).Returns(appSetting);
        
        _emailService = new EmailSenderService(_smtpClientMoq.Object, configMoq.Object);
        _mailSettings = appSetting.MailSettings;
    }

    [Fact]
    public async Task SendAsync_RequestModelIsNull_ThrowArgumentNullException()
    {
        var sendMethod = async () => await _emailService.SendAsync(null);
        await Assert.ThrowsAsync<ArgumentNullException>(sendMethod);
    }

    [Theory]
    [MemberData(nameof(TestDataGenerator.GetEmailRequestWithNullReceptors), MemberType = typeof(TestDataGenerator))]
    public async Task SendAsync_RequestModelReceptorMailIsNull_ThrowArgumentException(SendEmailRequest request)
    {
        var sendMethod = async () => await _emailService.SendAsync(request);
        var exception = await Assert.ThrowsAsync<ArgumentException>(sendMethod);
        Assert.Contains("Receptor",exception.Message);
    }

    [Theory]
    [MemberData(nameof(TestDataGenerator.GetEmailRequestWithNullBody), MemberType = typeof(TestDataGenerator))]
    public async Task SendAsync_RequestModelBodyIsNull_ThrowArgumentException(SendEmailRequest request)
    {
        var sendMethod = async () => await _emailService.SendAsync(request);
        var exception = await Assert.ThrowsAsync<ArgumentException>(sendMethod);
        Assert.Contains("Body" , exception.Message);
    }

    [Fact]
    public async Task SendAsync_WhenCalled_SmtpClientShouldConnect()
    {
        SendEmailRequest request = TestDataGenerator.CreateSampleRequest();
        await _emailService.SendAsync(request);
        _smtpClientMoq.Verify(s =>s.ConnectAsync(_mailSettings.Server, _mailSettings.Port, true, It.IsAny<CancellationToken>()));
    }
    
    
    [Fact]
    public async Task SendAsync_WhenCalled_SmtpClientShouldAuthenticate()
    {
        SendEmailRequest request = TestDataGenerator.CreateSampleRequest();
        await _emailService.SendAsync(request);
        _smtpClientMoq.Verify(s => s.AuthenticateAsync( _mailSettings.UserName, _mailSettings.Password, It.IsAny<CancellationToken>()));
    }

    [Fact]
    public async Task SendAsync_WhenCalled_SmtpClientShouldSend()
    {
        SendEmailRequest request = TestDataGenerator.CreateSampleRequest();
        await _emailService.SendAsync(request);
        _smtpClientMoq.Verify(s=> s.SendAsync(null,It.IsAny<MimeMessage>(),It.IsAny<CancellationToken>(),null));
    }
    
    [Fact]
    public async Task SendAsync_WhenCalled_SmtpClientShouldDisconnect()
    {
        SendEmailRequest request = TestDataGenerator.CreateSampleRequest();
        await _emailService.SendAsync(request);
        _smtpClientMoq.Verify(s=> s.DisconnectAsync(true,It.IsAny<CancellationToken>()));
    }
}