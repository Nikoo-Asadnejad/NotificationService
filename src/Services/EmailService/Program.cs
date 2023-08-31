using EmailService.Configurations;
using EmailService.Consumers;
using MassTransit;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InjectService(builder.Configuration);
builder.Services.AddRabbitConsumer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigurePipeline();
app.Run();

