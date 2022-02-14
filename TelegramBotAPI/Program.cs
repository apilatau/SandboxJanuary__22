using Hangfire;
using Telegram.Bot;
using TelegramBotAPI;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("tgwebhook")
            .AddTypedClient<ITelegramBotClient>(httpClient =>
            new TelegramBotClient("5120059284:AAEW1xdREZG09BSV5akzkZaifa_nEUJOr48", httpClient));


builder.Services.AddHangfire(x => x.UseSqlServerStorage("<connection string>"));
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseHangfireDashboard();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "Hello World!");

app.Run();
