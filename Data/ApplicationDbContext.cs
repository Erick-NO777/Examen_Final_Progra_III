using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ConstructoraUH.Models;

namespace ConstructoraUH.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        // Especificamos los nombres de las tablas correctamente.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().ToTable("Empleadoes");
            modelBuilder.Entity<Proyecto>().ToTable("Proyectoes");
            modelBuilder.Entity<Asignacion>().ToTable("Asignacions");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Empleado> Empleadoes { get; set; }
        public DbSet<Proyecto> Proyectoes { get; set; }
        public DbSet<Asignacion> Asignacions { get; set; }
    }
}