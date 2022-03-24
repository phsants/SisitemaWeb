using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SisitemaWeb.Areas.Identity.Data;
using SisitemaWeb.Data;
using SisitemaWeb.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SisitemaWebContextConnection");
builder.Services.AddDbContext<SisitemaWebContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<SisitemaWebUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SisitemaWebContext>();
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapRazorPages();

app.Run();
