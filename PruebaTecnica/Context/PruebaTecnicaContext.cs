using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Context
{
    public class PruebaTecnicaContext : DbContext
    {
        public PruebaTecnicaContext(DbContextOptions<PruebaTecnicaContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .HasKey(p => p.ProductoId);
        }
    }
}
