using SmsService.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InjectService(builder.Configuration);
builder.Services.AddRabbitConsumer();

var app = builder.Build();
app.ConfigurePipeline();
app.Run();