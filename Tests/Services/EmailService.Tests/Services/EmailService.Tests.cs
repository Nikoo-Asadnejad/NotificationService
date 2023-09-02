using EmailContract.Models;
using EmailService.Configurations;
using EmailService.Interfaces;
using EmailService.Services;
using EmailService.Tests.TestData;
using MailKit.Net.Smtp;
using MassTransit;
using Microsoft.Extensions.Configuration;
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
        _emailService = new EmailSenderService(_smtpClientMoq.Object);
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@"appsettings.json", false, false)
            .AddEnvironmentVariables()
            .Build();
        
        config.GetSection("MailSettings").Bind(Configuration.AppSetting);
        _mailSettings = Configuration.AppSetting.MailSettings;
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
        var ex = await Assert.ThrowsAsync<ArgumentException>(sendMethod);
        Assert.True(ex.Message.Contains("Receptor"));
    }

    [Theory]
    [MemberData(nameof(TestDataGenerator.GetEmailRequestWithNullBody), MemberType = typeof(TestDataGenerator))]
    public async Task SendAsync_RequestModelBodyIsNull_ThrowArgumentException(SendEmailRequest request)
    {
        var sendMethod = async () => await _emailService.SendAsync(request);
        var ex = await Assert.ThrowsAsync<ArgumentException>(sendMethod);
        Assert.True(ex.Message.Contains("Body"));
    }

    [Fact]
    public async Task SendAsync_WhenCalled_SmtpClientShouldConnect()
    {
        SendEmailRequest request = TestDataGenerator.CreateSampleRequest();
        await _emailService.SendAsync(request);
        _smtpClientMoq.Verify(s =>
            s.ConnectAsync(_mailSettings.Server, _mailSettings.Port, true, It.IsAny<CancellationToken>()));
    }
    
    
    [Fact]
    public async Task SendAsync_WhenCalled_SmtpClientShouldAuthenticate()
    {
        SendEmailRequest request = TestDataGenerator.CreateSampleRequest();
        await _emailService.SendAsync(request);
        _smtpClientMoq.Verify(s =>
            s.Authenticate( _mailSettings.UserName, _mailSettings.Password, It.IsAny<CancellationToken>()));
    }

    // [Fact]
    // public async Task SendAsync_WhenCalled_SmtpClientShouldSend()
    // {
    //     SendEmailRequest request = TestDataGenerator.CreateSampleRequest();
    //     await _emailService.SendAsync(request);
    //     _smtpClientMoq.Verify(s => s.SendAsync(
    //         It.Is<MimeMessage>(m =>
    //                                      m.Subject.Equals(request.Subject) && m.To.Mailboxes.Any(m => m.Address.Equals(request.ReceptorMail) && m.Name.Equals(request.ReceptorName)))),
    //         It.IsAny<CancellationToken>(),
    //         null));
    // }
}