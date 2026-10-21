using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TiendaCRUD
{
    public class TiendaContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string rutaBD = Path.GetFullPath(
    Path.Combine(
        AppContext.BaseDirectory,
        @"..\..\..\TiendaDB.mdf"));

                optionsBuilder.UseSqlServer(
                    $@"Server=(LocalDB)\MSSQLLocalDB;AttachDbFilename={rutaBD};Integrated Security=True;TrustServerCertificate=True;");
            }
        }
    }
}