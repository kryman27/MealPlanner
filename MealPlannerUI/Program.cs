using MealPlannerUI.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Globalization;
using MudBlazor.Services;
using MealPlannerUI.ConfigManagerNamespace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<MealService>();
builder.Services.AddSingleton<TokenBearerService>();
builder.Services.AddSingleton<UserPreferencesService>();
builder.Services.AddSingleton<UserManagerService>();
//builder.Services.AddSingleton<ConfigManager>();
builder.Services.AddMudServices();

//config from json file
var config = ConfigManager.GetInstance();


//var prepareToken = new TokenBearerService();
//var retreivedToken = prepareToken.RetreiveToken("MealPlannerAPI");
//prepareToken.Token = retreivedToken;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseHttpsRedirection();

app.Run();
