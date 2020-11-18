using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adotapet.Models;

namespace Domain.Entidades
{
    public class Context : DbContext
    {
        public DbSet<Pet> Pet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=adotapet3;Integrated Security=True");
        }

        public DbSet<adotapet.Models.Ong> Ong { get; set; }

        public DbSet<adotapet.Models.Adotante> Adotante { get; set; }

        public DbSet<adotapet.Models.Entrevista> Entrevista { get; set; }
    }
}
