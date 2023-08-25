using SmsService.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InjectService(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigurePipeline();