using VaultGuard.Api;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services, builder.Environment);

var app = builder.Build();

startup.Configure(app);

app.Run();