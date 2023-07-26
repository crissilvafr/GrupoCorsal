using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GrupoCorsal.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
//dotnet aspnet-codegenerator identity -dc GrupoCorsal.Data.ApplicationDbContext --files "Account.Register;Account.Login;Account.Logout;Account.RegisterConfirmation" --useSqLite

/*
dotnet aspnet-codegenerator controller -name CotizacionController -m Cotizacion -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name MarcaController -m Marca -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name MarcaProductoController -m MarcaProducto -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name MensualidadController -m Mensualidad -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name PersonaController -m Persona -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name PersonaDetalleController -m PersonaDetalle -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name ProductoController -m Producto -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name SexoController -m Sexo -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name SucursalController -m Sucursal -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name TipoPersonaController -m TipoPersona -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name TipoUsuarioController -m TipoUsuario -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet aspnet-codegenerator controller -name VersionController -m Version -dc GrupoCorsal.Data.ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

*/