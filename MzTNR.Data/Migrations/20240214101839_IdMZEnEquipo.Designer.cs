﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MzTNR.Data.Data;

#nullable disable

namespace MzTNR.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240214101839_IdMZEnEquipo")]
    partial class IdMZEnEquipo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MzTNR.Data.Models.Identity.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("MzTNR.Data.Models.Identity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MzTNR.Data.Models.Identity.AppUserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Borrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CoordenadaX")
                        .HasColumnType("longtext");

                    b.Property<string>("CoordenadaY")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<int?>("ProvinciaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Equipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("longtext");

                    b.Property<bool>("Borrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("CiudadId")
                        .HasColumnType("int");

                    b.Property<int?>("IdMz")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("NombreEquipo")
                        .HasColumnType("longtext");

                    b.Property<string>("UsuarioMZ")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Estadistica", b =>
                {
                    b.Property<string>("Clave")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Visitas")
                        .HasColumnType("int");

                    b.HasKey("Clave");

                    b.ToTable("Estadisticas");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.FaseGrupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("EquipoId")
                        .HasColumnType("int");

                    b.Property<int>("GolesAFavor")
                        .HasColumnType("int");

                    b.Property<int>("GolesEnContra")
                        .HasColumnType("int");

                    b.Property<int>("Grupo")
                        .HasColumnType("int");

                    b.Property<int>("PartidosEmpatados")
                        .HasColumnType("int");

                    b.Property<int>("PartidosGanados")
                        .HasColumnType("int");

                    b.Property<int>("PartidosPerdidos")
                        .HasColumnType("int");

                    b.Property<int>("Posicion")
                        .HasColumnType("int");

                    b.Property<int?>("TorneoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.HasIndex("TorneoId")
                        .IsUnique();

                    b.ToTable("FasesGrupos");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Imagen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TorneoId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("TorneoId")
                        .IsUnique();

                    b.ToTable("Imagen");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.LigaAmistosa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("EquipoId")
                        .HasColumnType("int");

                    b.Property<int>("GolesAFavor")
                        .HasColumnType("int");

                    b.Property<int>("GolesEnContra")
                        .HasColumnType("int");

                    b.Property<int>("PartidosEmpatados")
                        .HasColumnType("int");

                    b.Property<int>("PartidosGanados")
                        .HasColumnType("int");

                    b.Property<int>("PartidosPerdidos")
                        .HasColumnType("int");

                    b.Property<int>("Posicion")
                        .HasColumnType("int");

                    b.Property<int?>("TorneoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipoId");

                    b.HasIndex("TorneoId")
                        .IsUnique();

                    b.ToTable("LigasAmistosas");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Partido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("EquipoLocalId")
                        .HasColumnType("int");

                    b.Property<int?>("EquipoVisitanteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("FechaNumero")
                        .HasColumnType("int");

                    b.Property<int>("GolesLocal")
                        .HasColumnType("int");

                    b.Property<int>("GolesVisitante")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<int?>("TorneoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EquipoLocalId");

                    b.HasIndex("EquipoVisitanteId");

                    b.HasIndex("TorneoId");

                    b.ToTable("Partidos");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Playoff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Instancia")
                        .HasColumnType("int");

                    b.Property<int?>("TorneoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TorneoId");

                    b.ToTable("Playoffs");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Borrado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Provincias");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Torneo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Edicion")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<int>("TemporadaMZ")
                        .HasColumnType("int");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Torneos");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("MzTNR.Data.Models.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("MzTNR.Data.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("MzTNR.Data.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("MzTNR.Data.Models.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MzTNR.Data.Models.Identity.AppUserRole", b =>
                {
                    b.HasOne("MzTNR.Data.Models.Identity.AppRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MzTNR.Data.Models.Identity.AppUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Ciudad", b =>
                {
                    b.HasOne("MzTNR.Data.Models.TNR.Provincia", "Provincia")
                        .WithMany("Ciudades")
                        .HasForeignKey("ProvinciaId");

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Equipo", b =>
                {
                    b.HasOne("MzTNR.Data.Models.TNR.Ciudad", "Ciudad")
                        .WithMany("Equipos")
                        .HasForeignKey("CiudadId");

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.FaseGrupo", b =>
                {
                    b.HasOne("MzTNR.Data.Models.TNR.Equipo", "Equipo")
                        .WithMany()
                        .HasForeignKey("EquipoId");

                    b.HasOne("MzTNR.Data.Models.TNR.Torneo", "Torneo")
                        .WithOne("FasesGrupos")
                        .HasForeignKey("MzTNR.Data.Models.TNR.FaseGrupo", "TorneoId");

                    b.Navigation("Equipo");

                    b.Navigation("Torneo");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Imagen", b =>
                {
                    b.HasOne("MzTNR.Data.Models.TNR.Torneo", "Torneo")
                        .WithOne("Imagen")
                        .HasForeignKey("MzTNR.Data.Models.TNR.Imagen", "TorneoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Torneo");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.LigaAmistosa", b =>
                {
                    b.HasOne("MzTNR.Data.Models.TNR.Equipo", "Equipo")
                        .WithMany("LigasAmistosas")
                        .HasForeignKey("EquipoId");

                    b.HasOne("MzTNR.Data.Models.TNR.Torneo", "Torneo")
                        .WithOne("LigasAmistosas")
                        .HasForeignKey("MzTNR.Data.Models.TNR.LigaAmistosa", "TorneoId");

                    b.Navigation("Equipo");

                    b.Navigation("Torneo");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Partido", b =>
                {
                    b.HasOne("MzTNR.Data.Models.TNR.Equipo", "EquipoLocal")
                        .WithMany()
                        .HasForeignKey("EquipoLocalId");

                    b.HasOne("MzTNR.Data.Models.TNR.Equipo", "EquipoVisitante")
                        .WithMany()
                        .HasForeignKey("EquipoVisitanteId");

                    b.HasOne("MzTNR.Data.Models.TNR.Torneo", "Torneo")
                        .WithMany("Partidos")
                        .HasForeignKey("TorneoId");

                    b.Navigation("EquipoLocal");

                    b.Navigation("EquipoVisitante");

                    b.Navigation("Torneo");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Playoff", b =>
                {
                    b.HasOne("MzTNR.Data.Models.TNR.Torneo", null)
                        .WithMany("Playoffs")
                        .HasForeignKey("TorneoId");
                });

            modelBuilder.Entity("MzTNR.Data.Models.Identity.AppRole", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("MzTNR.Data.Models.Identity.AppUser", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Ciudad", b =>
                {
                    b.Navigation("Equipos");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Equipo", b =>
                {
                    b.Navigation("LigasAmistosas");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Provincia", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("MzTNR.Data.Models.TNR.Torneo", b =>
                {
                    b.Navigation("FasesGrupos");

                    b.Navigation("Imagen");

                    b.Navigation("LigasAmistosas");

                    b.Navigation("Partidos");

                    b.Navigation("Playoffs");
                });
#pragma warning restore 612, 618
        }
    }
}
