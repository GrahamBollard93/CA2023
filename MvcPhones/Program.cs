using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcPhones.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("MvcPhonesConnection") ?? 
    throw new InvalidOperationException("Connection string 'MvcPhonesConnection' not found.");

builder.Services.AddDbContext<MvcPhonesDbContext>(options => 
options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
    options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MvcPhonesDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register HTTP Client - For RetroShirtsApi/Products
builder.Services.AddHttpClient("PhonesApi", client =>
{
    client.BaseAddress = new Uri("http://localhost:5002/");
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue(
            mediaType: "application/json",
            quality: 1.0
        )
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Phones/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Phones}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
