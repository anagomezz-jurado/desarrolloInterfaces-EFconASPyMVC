using EFconASPyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFconASPyMVC.Context
{
    public class MyDbContext : DbContext
    {
        //Establecemos el motor de la base de datos
        //especificando su cadena de conexión
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Clave primaria compuesta de PuestoHermano
            modelBuilder.Entity<PuestoHermano>().HasKey(ph => new { ph.PuestoId, ph.HermanoId });
        }

        //creamos una tabla llamada Hermandad a partir de nuestra clase Hermandad
        public DbSet<Hermandad> Hermandad { get; set; }

        //creamos una tabla llamada Hermano a partir de nuestra clase Hermano
        public DbSet<Hermano> Hermano { get; set; }

        //creamos una tabla llamada Puesto a partir de nuestra clase Puesto
        public DbSet<Puesto> Puesto { get; set; }

        //creamos una tabla llamada PuestoHermano a partir de nuestra clase PuestoHermano
        public DbSet<PuestoHermano> PuestoHermano { get; set; }

        public DbSet<Tunica> Tunica { get; set; }

    }
}
