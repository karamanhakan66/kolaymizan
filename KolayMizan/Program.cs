using Microsoft.EntityFrameworkCore;
using KolayMizan.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Veritabanı bağlantısını yapılandır
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Servis kayıtları
// Şimdilik servis kayıtlarını kaldırıyoruz
/*
builder.Services.AddScoped<IKullaniciService, KullaniciService>();
builder.Services.AddScoped<ICariService, CariService>();
builder.Services.AddScoped<IUrunService, UrunService>();
builder.Services.AddScoped<IFaturaService, FaturaService>();
builder.Services.AddScoped<IOdemeService, OdemeService>();
builder.Services.AddScoped<ITahsilatService, TahsilatService>();
builder.Services.AddScoped<IBankaService, BankaService>();
builder.Services.AddScoped<IGiderService, GiderService>();
*/

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
