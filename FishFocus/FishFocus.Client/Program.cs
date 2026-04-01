using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using FishFocus.Client;
using FishFocus.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<AuthApiService>();

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();