using Microsoft.EntityFrameworkCore;

namespace Libreria.Data
{
    public class BDLibreriaDBContext : DbContext
    {
        public BDLibreriaDBContext(DbContextOptions<BDLibreriaDBContext> options) : base(options) { }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
    }
}

