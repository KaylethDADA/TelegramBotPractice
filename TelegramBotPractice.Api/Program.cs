using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using TelegramBotPractice.Api;
using TelegramBotPractice.Api.Options;
using TelegramBotPractice.Application;
using TelegramBotPractice.Infrastructure;
using TelegramBotPractice.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMappings();
builder.Services.AddInfrastructure();
builder.Services.AddServiceApplication();
builder.Services.AddControllers();

//EF
var connectionString = builder.Configuration.GetConnectionString(ConnectionStrings.Configuration);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

//TgBot
var botConfigurationSection = builder.Configuration.GetSection(BotConfiguration.Configuration);
builder.Services.Configure<BotConfiguration>(botConfigurationSection);
var botConfiguration = botConfigurationSection.Get<BotConfiguration>();

// Регистрация HttpClient и TelegramBotClient
builder.Services.AddHttpClient("telegram_bot_client")
                .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
                {
                    BotConfiguration? botConfig = sp.GetConfiguration<BotConfiguration>();
                    TelegramBotClientOptions options = new(botConfig.BotToken);
                    return new TelegramBotClient(options, httpClient);
                });

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

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

app.MapControllers();
app.Run();