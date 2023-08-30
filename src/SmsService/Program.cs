using MassTransit;
using SmsService.Configurations;
using SmsService.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InjectService(builder.Configuration);

var app = builder.Build();
app.ConfigurePipeline();

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("send-email-event", e =>
    {
        e.Consumer<SmsConsumer>();
    });
});

await busControl.StartAsync(new CancellationToken());
try
{
    Console.WriteLine("Press enter to exit");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}

app.Run();