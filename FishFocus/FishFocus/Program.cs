using FishFocus.Components;
using FishFocus.Data;
using FishFocus.Interfaces;
using FishFocus.Repositories;
using FishFocus.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using MudBlazor;
using MudBlazor.Services;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFishRepository, FakeFishRepository>();
builder.Services.AddScoped<FishingService>();

builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddControllers();

var jwtKey = builder.Configuration["Jwt:Key"]!;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddMudBlazorSnackbar(config =>
{
    config.PositionClass = Defaults.Classes.Position.BottomLeft;
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();

        /*
        var fishRepo = services.GetRequiredService<IFishRepository>();
        var fishesFromRepo = await fishRepo.GetAllFishesAsync();
        foreach (var repoFish in fishesFromRepo)
        {
            var dbFish = await context.Fishes.FirstOrDefaultAsync(f => f.Name == repoFish.Name);
            if (dbFish != null) {
                dbFish.Description = repoFish.Description;
                dbFish.Points = repoFish.Points;
            } else {
                context.Fishes.Add(repoFish);
            }
        }
        await context.SaveChangesAsync();
        */

        Console.WriteLine("---> База данных в порядке! <---");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"---> Ошибка БД: {ex.Message} <---");
    }
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(FishFocus.Client._Imports).Assembly);

app.Run();