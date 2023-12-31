﻿// <auto-generated />
using System;
using GrupoCorsal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrupoCorsal.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.20");

            modelBuilder.Entity("GrupoCorsal.Models.Cotizacion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("anio")
                        .HasColumnType("INTEGER");

                    b.Property<double>("apertura_id")
                        .HasColumnType("REAL");

                    b.Property<double>("comision_asesor")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("fecha_contratacion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fecha_cotizacion")
                        .HasColumnType("TEXT");

                    b.Property<int>("folio")
                        .HasColumnType("INTEGER");

                    b.Property<double>("monto")
                        .HasColumnType("REAL");

                    b.Property<int>("persona_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("produto_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("usuario_id")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Cotizacion");
                });

            modelBuilder.Entity("GrupoCorsal.Models.Marca", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("GrupoCorsal.Models.MarcaProducto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("activo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("marca_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("producto_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("version_id")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("MarcaProducto");
                });

            modelBuilder.Entity("GrupoCorsal.Models.Mensualidad", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("activo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("cotizacion_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("mensualidad")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("numAutorizacion")
                        .HasColumnType("INTEGER");

                    b.Property<int>("status")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Mensualidad");
                });

            modelBuilder.Entity("GrupoCorsal.Models.Persona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("apellido1")
                        .HasColumnType("TEXT");

                    b.Property<string>("apllido2")
                        .HasColumnType("TEXT");

                    b.Property<string>("curp")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fecha_nacimiento")
                        .HasColumnType("TEXT");

                    b.Property<int>("folio")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("rfc")
                        .HasColumnType("TEXT");

                    b.Property<int>("sexo_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tipo_persona")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("GrupoCorsal.Models.PersonaDetalle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("beneficiario")
                        .HasColumnType("TEXT");

                    b.Property<string>("correo")
                        .HasColumnType("TEXT");

                    b.Property<string>("domicilio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("ingresos")
                        .HasColumnType("REAL");

                    b.Property<string>("observaciones")
                        .HasColumnType("TEXT");

                    b.Property<int>("persona_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("referencia1")
                        .HasColumnType("TEXT");

                    b.Property<string>("referencia2")
                        .HasColumnType("TEXT");

                    b.Property<string>("telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("PersonaDetalle");
                });

            modelBuilder.Entity("GrupoCorsal.Models.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("GrupoCorsal.Models.Sexo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Sexo");
                });

            modelBuilder.Entity("GrupoCorsal.Models.Sucursal", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("GrupoCorsal.Models.TipoPersona", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("TipoPersona");
                });

            modelBuilder.Entity("GrupoCorsal.Models.TipoUsuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("GrupoCorsal.Models.Version", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Version");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
