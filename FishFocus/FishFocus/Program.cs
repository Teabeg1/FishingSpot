using FishFocus.Client.Pages;
using FishFocus.Components;
using MudBlazor.Services;

using FishFocus.Services;
using FishFocus.Interfaces;

builder.Services.AddScoped<FishingService>();

builder.Services.AddScoped<IFishRepository, FakeFishRepository>();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FishFocus.Client._Imports).Assembly);
app.Run();
