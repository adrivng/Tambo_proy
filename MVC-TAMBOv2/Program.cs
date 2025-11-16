using Microsoft.EntityFrameworkCore;
using MVC_TAMBOv2.Models;

var builder = WebApplication.CreateBuilder(args);

// ============================================================
// 1. Registrar servicios de MVC
// ============================================================
builder.Services.AddControllersWithViews();

// ============================================================
// 2. Registrar EF Core con SQL Server
// ============================================================
builder.Services.AddDbContext<TamboContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("TamboCn");
    options.UseSqlServer(connectionString);
});

// ============================================================
// 3. Habilitar SESIONES  (necesario para Login y Roles)
// ============================================================
builder.Services.AddSession(); // <-- agregado por LOGIN/ROLES


var app = builder.Build();

// ============================================================
// 4. Manejo de errores y seguridad (modo producción)
// ============================================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ============================================================
// 5. Middlewares esenciales
// ============================================================
app.UseHttpsRedirection();

// ➕ Necesario para cargar CSS, JS, imágenes
app.UseStaticFiles(); // <-- agregado (sin esto no carga estilos)

// Routing general
app.UseRouting();

// Autorización (aunque no usas auth todavía, se deja ordenado)
app.UseAuthorization();

// Activar SESIÓN (importante → ANTES de MapControllerRoute)
app.UseSession(); // <-- agregado por LOGIN/ROLES


// ============================================================
// 6. Ruta por defecto
//    ✔ Tú pediste que inicie en MenuPrincipal
// ============================================================
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tambo}/{action=MenuPrincipal}/{id?}")
    .WithStaticAssets();

app.Run();


