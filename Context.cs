using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicds.Models;

namespace apicds
{
    public class Context: DbContext
    {
        internal object detalleAlquiler;

        public Context(DbContextOptions<Context> options): base(options)
        {
        }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Alquiler> alquilers { get; set; }             
        public DbSet<Sancion> sancions { get; set; }
        public DbSet<CD> cd{ get; set; }
        public DbSet<DetalleAlquiler> detalleAlquilers{ get; set; }
       
    }
}
