using Microsoft.EntityFrameworkCore;
using MVC_TAMBOv2.Models;
using MVC_TAMBOv2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TamboContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("TamboCn");
    options.UseSqlServer(connectionString);
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tambo}/{action=MenuPrincipal}/{id?}")
    .WithStaticAssets();


app.Run();
