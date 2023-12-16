using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuiselITELEC1C.Data;
using QuiselITELEC1C.Services;
using System;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 5;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireDigit = true;
    options.Password.RequireNonAlphanumeric = true;
}).AddEntityFrameworkStores<AppDbContext>();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
context.Database.EnsureCreated();
//context.Database.EnsureDeleted();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
