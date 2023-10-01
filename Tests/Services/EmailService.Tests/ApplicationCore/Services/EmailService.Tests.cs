using System.Net.Mail;
using EmailContract.Models;
using EmailService.Configurations;
using EmailService.Interfaces;
using EmailService.Services;
using EmailService.Tests.TestData;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;

namespace EmailService.Tests.Services;

public sealed class EmailService_Tests
{
    private readonly IEmailService _emailService;
    private readonly Mock<ISmtpClient> _smtpClientMoq;
    private readonly MailSetting _mailSettings;
    private SendEmailRequest _sendEmailRequest = TestDataGenerator.CreateSampleRequest();

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
    [EmailWithNullReceptorData]
    public async Task SendAsync_RequestModelReceptorMailIsNull_ThrowArgumentException(SendEmailRequest request)
    {
        var sendMethod = async () => await _emailService.SendAsync(request);
        var exception = await Assert.ThrowsAsync<ArgumentException>(sendMethod);
        Assert.Contains("Receptor",exception.Message);
    }

    [Theory]
    [EmailRequestWithNullBodyData]
    public async Task SendAsync_RequestModelBodyIsNull_ThrowArgumentException(SendEmailRequest request)
    {
        var sendMethod = async () => await _emailService.SendAsync(request);
        var exception = await Assert.ThrowsAsync<ArgumentException>(sendMethod);
        Assert.Contains("Body" , exception.Message);
    }
    
    [Fact]
    public async Task SendAsync_WhenCalled_SmtpClientShouldSend()
    {
        await _emailService.SendAsync(_sendEmailRequest);
        _smtpClientMoq.Verify(s=> s.SendAsync(It.IsAny<MailMessage>(),It.IsAny<CancellationToken>()));
    }
    
  
}