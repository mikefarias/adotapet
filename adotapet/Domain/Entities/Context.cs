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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=adotapet3;Integrated Security=True");
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
        }

    }
}
