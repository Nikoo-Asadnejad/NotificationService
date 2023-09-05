using EmailContract.Models;
using EmailService.Consumers;
using EmailService.Interfaces;
using EmailService.Tests.TestData;
using MassTransit;
using Moq;

namespace EmailService.Tests.Consumers;

public class EmailConsumerTests
{
    private readonly Mock<IEmailService> _emailServiceMoq;
    private readonly EmailConsumer _emailConsumer;

    public EmailConsumerTests()
    {
        _emailServiceMoq = new Mock<IEmailService>();
        _emailConsumer = new EmailConsumer(_emailServiceMoq.Object);
    }

    [Fact]
    public async Task Consume_ContextIsNull_ThrowsArgumentNullException()
    {
        var consumeFunc = async () => await _emailConsumer.Consume(null); 
        await Assert.ThrowsAsync<ArgumentNullException>(consumeFunc);
    }
    
  
}