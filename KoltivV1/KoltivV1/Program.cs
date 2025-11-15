using KoltivV1.Application;
using KoltivV1.Components;
using KoltivV1.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .WriteTo.MSSqlServer(
        connectionString: builder.Configuration["ConnectionStrings:DefaultConnection"],
        sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlDatabase = true, AutoCreateSqlTable = true })
    .CreateLogger();

builder.Host.UseSerilog();

// DBContext

builder.Services.AddDbContextFactory<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
    options.EnableSensitiveDataLogging(true);
});

// Repository

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddHttpClient("WeatherAPI", client =>
{
    client.BaseAddress = new Uri("https://api.weather.gov/");
});





var app = builder.Build();


//logger.Debug("----------------- TEST Application Starting Up");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
;

app.Run();
