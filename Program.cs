using Microsoft.EntityFrameworkCore;
using RencanaProduksiSoalDua.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Register DbContext with SQL Server
// Tambahkan koneksi EF Core dengan logging
builder.Services.AddDbContext<ProductionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .EnableSensitiveDataLogging());
// Add MVC services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enforce HTTPS
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure default routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Production}/{action=Index}/{id?}");

app.Run();
