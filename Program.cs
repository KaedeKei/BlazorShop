using BlazorShop.Data;
using BlazorShop.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//builder.Services.AddSingleton<ICatalog>(new InFileCatalog("products.txt"));
//builder.Services.AddSingleton<ICatalog>(new InJsonFileCatalog("products.json"));
//builder.Services.AddSingleton<ICatalog, InMemoryCatalog>();
builder.Services.AddScoped<ICatalog, SqliteCatalog>();
//builder.Services.AddSingleton<ProductService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ITime, TimeUTC>();
builder.Services.AddSingleton<ISendMail, SendMailKit>();


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
