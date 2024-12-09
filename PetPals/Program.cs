using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetPals.Data;
using PetPals.Data.Models;
using PetPals.Services.Data.Interfaces;
using PetPals.Web.Infrastructure.Extensions;
using static PetPals.Common.GeneralAppConstants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<PetPalsDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
})
 .AddRoles<IdentityRole<Guid>>()
 .AddEntityFrameworkStores<PetPalsDbContext>();


builder.Services.AddApplicationServices(typeof(IPetService));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapRazorPages();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.SeedAdministrator(DevelopmentAdminEmail);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    


app.Run();
