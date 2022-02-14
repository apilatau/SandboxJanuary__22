using BookBot.Models;
using BookBot.Services;
using Telegram.Bot;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHostedService<ConfigureWebHook>();
//builder.Services.AddSwaggerGen();
BotConfiguration BotConfig = builder.Configuration.GetSection("BotConfiguration").Get<BotConfiguration>();

builder.Services.AddHttpClient("TelegramDotNetBot")
    .AddTypedClient<ITelegramBotClient>(httpClient =>
        new TelegramBotClient(BotConfig.Token, httpClient));

builder.Services.AddScoped<HandleUpdateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();