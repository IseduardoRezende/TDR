using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using TDRConfiguration;
using TDRData;
using TDRData.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });

builder.Services.AddDbContext<TDRContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")
            ?? throw new InvalidOperationException("Connection string 'DbConnection' not found."),
        builder => builder.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null));
});

builder.Services.ConfigureRepositories();
builder.Services.ConfigureServices();
builder.Services.ConfigureAutoMapper();

var settingSection = builder.Configuration.GetSection("Settings");
builder.Services.Configure<Settings>(settingSection);

var settings = settingSection.Get<Settings>();
builder.Services.AddSingleton(settings!);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Adm", policy => policy.RequireClaim("Email", "admtdr@gmail.com"));
    options.AddPolicy("Admkitchen", policy => policy.RequireClaim("Email", "admtdrmanha@gmail.com", "admtdrnoite@gmail.com"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
