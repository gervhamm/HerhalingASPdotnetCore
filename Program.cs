using HerhalingASPdotnetCore.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using HerhalingASPdotnetCore.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(options => options.ResourcesPath="Resources")
    .AddDataAnnotationsLocalization(/*options => {
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(HerhalingASPdotnetCore.Resources.Models.User));
    }*/);

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

///<summary>
///Add the SignalR service to the project
///</summary>
builder.Services.AddSignalR();

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

///<summary>
///Map the ChatHub to the /chatHub endpoint
///</summary>   
app.MapHub<ChatHub>("/chatHub");

app.Run();

/* TODO: OPTIONEEL - BONUS PUNTEN

Volgende onderdeel is volledig optioneel, en kan worden erbijgenomen om bonus punten te verdienen:

    Probeer zelfstandig de SignalR library van Microsoft te integreren in je applicatie en zorg dat je door op een knop te drukken bij elke gebruiker een boodschap tevoorschijn laat komen.
    Documenteer (via ///) de verschillende stappen en leg uit hoe je de integratie hebt opgezet
*/

///<summary>
///Adding SignalR to the project
///Mostly following the steps from the Microsoft documentation
///https://learn.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-8.0&tabs=visual-studio
///Step 1: Add the client library @microsoft/signalr@latest
///Step 2: Create the ChatHub class in the Hubs folder
///Step 3: Add the SendMessage method to the ChatHub class
///Step 4: Add the SignalR service to the project
///Step 5: Map the ChatHub to the /chatHub endpoint
///Step 6: Add the SignalR client code to a new SignalR view
///Step 7: Add the javascript code to the SignalR under js/chat.js
///Step 8: Use the same chat.js functions in the Form view.
///</summary>
