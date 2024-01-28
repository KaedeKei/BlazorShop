using BlazorShop.Data;
using BlazorShop.Models;
using BlazorShop.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.CreateLogger();

try
{
	Log.Information("Starting web application");

	var builder = WebApplication.CreateBuilder(args);

	// Add services to the container.
	builder.Services.AddRazorPages();
	builder.Services.AddServerSideBlazor();

	builder.Host.UseSerilog();

	//builder.Host.UseSerilog((_, conf) =>
	//{
	//	conf
	//	.WriteTo.Console()
	//	.WriteTo.File("log-.txt",
	//   rollingInterval: RollingInterval.Day)
	//	;
	//});

	//builder.Services.AddSingleton<ICatalog>(new InFileCatalog("products.txt"));
	//builder.Services.AddSingleton<ICatalog>(new InJsonFileCatalog("products.json"));
	//builder.Services.AddSingleton<ICatalog, InMemoryCatalog>();
	//builder.Services.AddScoped<ICatalog, SqliteCatalogNotAsync> ();

	builder.Services.AddScoped<ICatalogAsync, SqliteCatalogAsync>();
	builder.Services.AddScoped<ProductService>();
	builder.Services.AddSingleton<ITime, TimeUTC>();
	builder.Services.AddSingleton<IEmailSender, SmtpEmailSenderMailKit>();
	builder.Services.AddScoped<ISmtpConfiguration, SmptConfiguration>();

	var dbPath = "blazorShopDb.db";
	builder.Services.AddDbContext<AppDbContext>(
	   options => options.UseSqlite($"Data Source={dbPath}"));

	var app = builder.Build();


	// Configure the HTTP request pipeline.
	if (!app.Environment.IsDevelopment())
	{
		app.UseExceptionHandler("/Error");
		// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
		app.UseHsts();
	}

	app.UseHttpsRedirection();

	app.UseStaticFiles();

	app.UseRouting();

	app.MapBlazorHub();
	app.MapFallbackToPage("/_Host");

	app.Run();

}
catch (Exception ex)
{
	Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
	Log.CloseAndFlush();
}


