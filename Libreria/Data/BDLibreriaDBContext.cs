using Microsoft.EntityFrameworkCore;

namespace Libreria.Data
{
    public class BDLibreriaDBContext : DbContext
    {
        public BDLibreriaDBContext(DbContextOptions<BDLibreriaDBContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Libro> Libros { get; set; } = default!;
        public DbSet<Venta> Ventas { get; set; } = default!;
    }
}
