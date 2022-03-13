using BulkyBook.DataAcces;
using BulkyBook.DataAcces.Repository;
using BulkyBook.DataAcces.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
//builder.Services.AddRazorPages();
// the first use enter face and other use class of use the enterFace 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
    //this for add new route of folder {area=customer}
    pattern: "{Area=Customer}/{controller=Home}/{action=Index}/{id?}");
 /* we put home HomeController on Customer file and CategoryController
    on  on area file  after this we transfer view file to Customer view and 
    and home view to view on both */

app.Run();
