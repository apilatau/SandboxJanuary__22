using Telegram.Bot;
using TelegramBotAPI;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("tgwebhook")
            .AddTypedClient<ITelegramBotClient>(httpClient =>
            new TelegramBotClient("5120059284:AAEW1xdREZG09BSV5akzkZaifa_nEUJOr48", httpClient));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
