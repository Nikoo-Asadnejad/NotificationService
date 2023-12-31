using Moq;
using SmsContract.Enums;
using SmsContract.Models;
using SmsService.Interfaces;
using SmsService.Services;
using SmsService.Tests.TestData;
using SmsService.Tests.TestData.DataAttributes;

namespace SmsService.Tests.Services;

public sealed class SmsService_Tests
{
    private readonly ISmsService _smsService;
    private readonly Mock<ISmsProvider> _providerMoq;
    private SendSmsRequest _sendSmsRequest = TestDataGenerator.CreateSampleRequest();
    public SmsService_Tests()
    {
        Mock<ISmsProvider> providerMoq = new();
        Func<Provider, ISmsProvider> funcProvider = (provider) => providerMoq.Object;
        _providerMoq = providerMoq;
        _smsService = new SendSmsService(funcProvider);
    }
    
    [Fact]
    public async Task SendAsync_RequestModelIsNull_ThrowArgumentNullException()
    {
        var sendMethod = async () => await _smsService.SendAsync(null);
        await Assert.ThrowsAsync<ArgumentNullException>(sendMethod);
    }

    [Theory]
    [SmsRequestWithNullReceptorData]
    public async Task SendAsync_RequestModelReceptorMailIsNull_ThrowArgumentException(SendSmsRequest request)
    {
        var sendMethod = async () => await _smsService.SendAsync(request);
        var exception = await Assert.ThrowsAsync<ArgumentException>(sendMethod);
        Assert.Contains("Receptor",exception.Message);
    }

    [Theory]
    [SmsRequestWithNullMessageData]
    public async Task SendAsync_RequestModelBodyIsNull_ThrowArgumentException(SendSmsRequest request)
    {
        var sendMethod = async () => await _smsService.SendAsync(request);
        var exception = await Assert.ThrowsAsync<ArgumentException>(sendMethod);
        Assert.Contains("Message" , exception.Message);
    }
    
    [Fact]
    public async Task SendAsync_ProviderNotValid_ThrowsProvideNotValidException()
    {
        SendSmsRequest request = TestDataGenerator.CreateUnvalidProviderRequest();
        Func<Task<SendSmsResponse>> func = async () =>  await _smsService.SendAsync(request);
        Exception exception =  await Assert.ThrowsAsync<Exception>(func);
        Assert.Contains("Provider", exception.Message);
    }
    
    [Fact]
    public async Task SendAsync_WhenCalled_ProviderSendShouldBeCalled()
    {
        await _smsService.SendAsync(_sendSmsRequest);
        _providerMoq.Verify(p=> p.SendAsync(_sendSmsRequest));
    }
    
    
}