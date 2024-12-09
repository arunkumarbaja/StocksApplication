using StocksApp.ServiceContracts;
using StocksApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddScoped<FinnhubService>();
builder.Services.AddScoped<StockService>();

var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();
