using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebsiteBlogs.Data;
using WebsiteBlogs.Models;
//using WebsiteBlogs.Models.Dtos;
//using WebsiteBlogs.Models.Entities;
using WebsiteBlogs.Services;
using WebsiteBlogs.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add seeding service
builder.Services.AddScoped<SeedingService>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

//Services.AddDbContext<ApplicationDbContext>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

/*
  Create a scope with CreateScope() so we can retrieve a service instance.
*/
using var scope = app.Services.CreateScope();
// Retrieve a SeedingService instance.
var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
// Call the SeedDatabase() method so that we can seed the database.
await seedingService.SeedDatabase();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
