using Microsoft.EntityFrameworkCore;
using MyApp.BLL;
using MyApp.DAL; // Adjust as needed

var builder = WebApplication.CreateBuilder(args);

// Configure services to use SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Item}/{action=Index}/{id?}");

app.Run();
