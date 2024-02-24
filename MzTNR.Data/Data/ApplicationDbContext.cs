using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MzTNR.Data.Models.Identity;
using MzTNR.Data.Models.TNR;

namespace MzTNR.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<LigaAmistosa> LigasAmistosas { get; set; }
        public DbSet<FaseGrupo> FasesGrupos { get; set; }
        public DbSet<Playoff> Playoffs { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Estadistica> Estadisticas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //++ PKs basados en IdMz
            builder.Entity<Equipo>()
                .HasKey(x => x.IdMz);

            builder.Entity<Partido>()
                .HasKey(x => x.IdMz);

            builder.Entity<LigaAmistosa>()
                .HasKey(x => x.IdMz);

            builder.Entity<Torneo>()
                .HasKey(x => x.IdMz);
                //.HasKey(x => new {x.Tipo, x.IdMz});

            //--
            
            //++ Relacion Users <<--->> Roles
            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            
            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            //-- Relacion Users <<--->> Roles

            //++ PK que no es Id en tabla Estadistica
            builder.Entity<Estadistica>()
                .HasKey(e => e.Clave);
            //-- PK que no es Id en tabla Estadistica

        }
    }
}
  /*
    Para ejecutar migraciones:
    Pararse en D:\Fuentes\MzTnr\back\MzTNR.data>
    Y ejecutar el comando
    dotnet ef migrations add XXXXXXXX --startup-project ../MzTNR.Web/MzTNR.Web.csproj
    Y si esta bien
    dotnet ef database update --startup-project ../MzTNR.Web/MzTNR.Web.csproj
    */