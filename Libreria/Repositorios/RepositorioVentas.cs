using Libreria.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libreria.Repositorios
{
    public class RepositorioVentas : IRepositorioVentas
    {
        private readonly BDLibreriaDBContext _context;

        public RepositorioVentas(BDLibreriaDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venta>> ObtenerTodosAsync()
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Libro)
                .ToListAsync();
        }

        public async Task<Venta?> ObtenerPorIdAsync(int id)
        {
            return await _context.Ventas
                .Include(v => v.Cliente)
                .Include(v => v.Libro)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AgregarAsync(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Venta venta)
        {
            _context.Ventas.Update(venta);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
