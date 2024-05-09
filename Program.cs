using HerhalingASPdotnetCore.Configuration;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization(options => options.ResourcesPath="Resources");

builder.Services.AddRequestLocalization(options =>
{
    options.SupportedCultures =
    [
        new CultureInfo("en"),
        new CultureInfo("fr"),
        new CultureInfo("nl")
    ];
    options.SupportedUICultures = options.SupportedCultures;

    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");
});

builder.Services.Configure<CustomConfiguration>(builder.Configuration.GetSection("Custom"));

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

app.UseRequestLocalization();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

/* TODO: OPTIONEEL - BONUS PUNTEN

Volgende onderdeel is volledig optioneel, en kan worden erbijgenomen om bonus punten te verdienen:

    Probeer zelfstandig de SignalR library van Microsoft te integreren in je applicatie en zorg dat je door op een knop te drukken bij elke gebruiker een boodschap tevoorschijn laat komen.
    Documenteer (via ///) de verschillende stappen en leg uit hoe je de integratie hebt opgezet
*/