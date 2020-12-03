using Microsoft.EntityFrameworkCore;
using ProyectoSimulacion.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSimulacion.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Presidentes> Presidente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = ./Data/Elecciones.db");
        }
    }
}
