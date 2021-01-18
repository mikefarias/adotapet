using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Domain.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Pet> Pet { get; set; }
        public DbSet<Ong> Ong { get; set; }
        public DbSet<Adotante> Adotante { get; set; }
        public DbSet<Entrevista> Entrevista { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Ong);
            modelBuilder.Entity<Entrevista>()
                .HasOne(p => p.Pet);
            modelBuilder.Entity<Entrevista>()
                .HasOne(p => p.Adotante);

        }

    }
}
