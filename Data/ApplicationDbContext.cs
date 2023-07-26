using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GrupoCorsal.Models;

namespace GrupoCorsal.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<GrupoCorsal.Models.Cotizacion>? Cotizacion { get; set; }
    public DbSet<GrupoCorsal.Models.Marca>? Marca { get; set; }
    public DbSet<GrupoCorsal.Models.MarcaProducto>? MarcaProducto { get; set; }
    public DbSet<GrupoCorsal.Models.Mensualidad>? Mensualidad { get; set; }
    public DbSet<GrupoCorsal.Models.Persona>? Persona { get; set; }
    public DbSet<GrupoCorsal.Models.PersonaDetalle>? PersonaDetalle { get; set; }
    public DbSet<GrupoCorsal.Models.Producto>? Producto { get; set; }
    public DbSet<GrupoCorsal.Models.Sucursal>? Sucursal { get; set; }
    public DbSet<GrupoCorsal.Models.TipoPersona>? TipoPersona { get; set; }
    public DbSet<GrupoCorsal.Models.TipoUsuario>? TipoUsuario { get; set; }
    public DbSet<GrupoCorsal.Models.Version>? Version { get; set; }
    public DbSet<GrupoCorsal.Models.Sexo>? Sexo { get; set; }
}
