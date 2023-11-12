using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetAsp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionstring = builder.Configuration.GetConnectionString("conn");
builder.Services.AddDbContext<ApplicationContext>(options=>options.UseSqlServer(connectionstring));

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
        name: "categoryCreate",
        pattern: "Categories/Create",
        defaults: new { controller = "Categorie", action = "Create" }
    );

// Add the route for the "Liste des Categories" link (assuming you've added it previously)
app.MapControllerRoute(
    name: "categoryList",
    pattern: "Categories/Index",
    defaults: new { controller = "Categorie", action = "Index" }
);


app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
