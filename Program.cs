using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configurar logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Kestrel to use HTTPS
builder.WebHost.ConfigureKestrel(options =>
{
	options.ListenLocalhost(5000); // HTTP
	options.ListenLocalhost(5001, listenOptions =>
	{
		listenOptions.UseHttps(); // HTTPS
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

var logger = app.Services.GetRequiredService<ILogger<Program>>();

logger.LogInformation("Before UseHttpsRedirection");

app.UseHttpsRedirection();

logger.LogInformation("After UseHttpsRedirection");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
