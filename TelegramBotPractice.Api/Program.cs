using Microsoft.EntityFrameworkCore;
using TelegramBotPractice.Api;
using TelegramBotPractice.Api.Controllers;
using TelegramBotPractice.Api.Options;
using TelegramBotPractice.Application;
using TelegramBotPractice.Infrastructure;
using TelegramBotPractice.Infrastructure.Context;
using TelegramBotPractice.Telegram;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMappings();
builder.Services.AddInfrastructure();
builder.Services.AddServiceApplication();
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddCommands();
builder.Services.ConfigureAuthentication();

//EF
var connectionString = builder.Configuration.GetConnectionString(ConnectionStrings.Configuration);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

//Reports
builder.Services.Configure<ExcelReportSettings>(builder.Configuration.GetSection(ExcelReportSettings.Configuration));

//TgBot
var botConfigurationSection = builder.Configuration.GetSection(BotConfiguration.Configuration);
builder.Services.Configure<BotConfiguration>(botConfigurationSection);
var botConfiguration = botConfigurationSection.Get<BotConfiguration>();
builder.Services.StartTbBot();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapBotWebhookRoute<BotController>(route: botConfiguration.Route);
app.MapControllers();
app.Run();