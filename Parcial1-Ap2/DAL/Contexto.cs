using Microsoft.EntityFrameworkCore;
using Parcial1_Ap2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial1_Ap2.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\PrimerParcial.db");
        }

        public DbSet<Producto> Productos { get; set; }
    }
}
