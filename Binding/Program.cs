using Binding.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using MVC_1.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Framwork service : already declear , already register
// built in service :  already declear , need register

// Add services to the container.
builder.Services.AddDbContext<FristEntity>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

// Custom service  "Register" 
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(Option=>
{
    // Password policy
    Option.Password.RequiredLength = 6;
    Option.Password.RequireNonAlphanumeric = false;
    Option.Password.RequireUppercase = false;
    Option.Password.RequireDigit = false;
    Option.Password.RequireLowercase = false;   
}
).AddEntityFrameworkStores<FristEntity>();
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

app.UseSession();

app.UseAuthentication();  //to check the user is login or not

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
