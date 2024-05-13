using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Magazin_Online.Data;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
        });

builder.Services.AddHttpContextAccessor();

builder.Services.AddSingleton<IFileProvider>(
    new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Utilizator}/{action=Login}");

    endpoints.MapControllerRoute(
    name: "addProduct",
    pattern: "Product/AddProduct/{id?}",
    defaults: new { controller = "Product", action = "AddProduct" });

    endpoints.MapControllerRoute(
       name: "MyProducts",
       pattern: "Products/MyProducts/{id?}",
       defaults: new { controller = "Products", action = "MyProducts" });

    endpoints.MapControllerRoute(
        name: "Profil",
        pattern: "Utilizator/Edit/{id?}",
        defaults: new { controller = "Utilizator", action = "Edit" });

    endpoints.MapControllerRoute(
        name: "error",
        pattern: "Error",
        new { controller = "Home", action = "Error" });

    endpoints.MapFallbackToController("Error", "Home");

});

app.Run();
