using QuickLink.Application;
using QuickLink.Infrastructure;
using QuickLink.Infrastructure.Utils;


var builder = WebApplication.CreateBuilder(args);

var dbManager = new MariaDatabaseManager(builder.Configuration);
dbManager.EnsureDatabase();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
