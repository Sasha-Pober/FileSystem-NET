using DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("default");

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FolderDBContext>(opt => opt.UseSqlServer(connectionString));
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
        name: "/Folder",
        pattern: "{controller=Folder}/{action=Index}/{name?}");

app.Run();
