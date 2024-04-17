using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IdentityDataContext>(Options =>
{
	var configuration = builder.Configuration.GetConnectionString("mysql_connection");
	var version = new MySqlServerVersion(new Version(8, 0, 36));
	Options.UseMySql(configuration, version);
});

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


//varsayýlan
app.MapControllerRoute(
	name: "default",
	pattern: "{area=admin}/{controller=Home}/{action=Index}/{id?}");

app.Run();
