using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Veri Tabaný Baðlantýsý
builder.Services.AddDbContext<IdentityDataContext>(Options =>
{
	var configuration = builder.Configuration.GetConnectionString("mysql_connection");
	var version = new MySqlServerVersion(new Version(8, 0, 36));
	Options.UseMySql(configuration, version);
});
//Bu kod Identityuser ve Role Ýçin Gerekli olan Þemayý projenin içine Dahil ediyor //AddEntityFrameworkStores<IdentityDataContext>(); blgilerin nerede deoplanacaðýný belirtir.
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<IdentityDataContext>().AddDefaultTokenProviders();



//Authentication configuration files ayarlarýný yapýlandýrýr(giriþ)
builder.Services.Configure<IdentityOptions>(options =>
{
    //Çeþitli Þifre Ayarlarý
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

    options.User.RequireUniqueEmail = false;
    //user giriþindeki harici kelimeleri engellemek için kullanýlýr
    //options.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnm@.";
    //5 sifre giriþ hakký var


    //Hesaba giriþ yapmak için hesabý onaylatma
    options.SignIn.RequireConfirmedEmail = false;


});

//Authorization  configuration files ayarlarýný yapýlandýrýr(Giriþ)
builder.Services.ConfigureApplicationCookie(options =>
{
    //Kullanýcýnýn authorize olmasý için gelecek sayfa
    options.LoginPath = "/Account/Login";
    //yetkisiz giriþlerde gönderilen sayfa  
    options.AccessDeniedPath = "/Yetkisiz/Index";
    //eðer kullanýcý sitede aktif ise cookie süresi sýfýrlanýr
    options.SlidingExpiration = true;
    //cookie saklama zamaný - //oturum sonlandýrma zamaný.
    options.ExpireTimeSpan = TimeSpan.FromDays(1);


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

//Projeye Kimlik giriþi Uygulamasýný Ekler.
app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Musteri",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Mutfak",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Garson",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

IdentityUserSeed.IdentityTestUser(app);
IdentityRoleSeed.IdentityTestRole(app);

app.Run();
