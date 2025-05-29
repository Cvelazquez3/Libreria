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
            var libro = await _context.Libros.FindAsync(venta.LibroId);
            if (libro == null)
                throw new Exception("El libro no existe.");

            if (venta.Cantidad > libro.Cantidad)
                throw new Exception($"Solo hay {libro.Cantidad} unidades disponibles.");

            // Resta correctamente la cantidad vendida del stock
            libro.Cantidad -= venta.Cantidad;

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();
        }




        public async Task ActualizarAsync(Venta venta)
        {
            var ventaExistente = await _context.Ventas.FindAsync(venta.Id);
            if (ventaExistente == null)
                throw new Exception("La venta no existe.");

            var libro = await _context.Libros.FindAsync(venta.LibroId);
            if (libro == null)
                throw new Exception("Libro no encontrado.");

            // Devuelve al stock la cantidad anterior vendida
            libro.Cantidad += ventaExistente.Cantidad;

            // Verifica que hay suficiente stock para aplicar la nueva cantidad
            if (venta.Cantidad > libro.Cantidad)
                throw new Exception($"No hay suficiente stock. Solo quedan {libro.Cantidad} unidades.");

            // Aplica nueva cantidad
            libro.Cantidad -= venta.Cantidad;

            // Actualiza campos
            ventaExistente.ClienteId = venta.ClienteId;
            ventaExistente.LibroId = venta.LibroId;
            ventaExistente.Fecha = venta.Fecha;
            ventaExistente.Cantidad = venta.Cantidad;

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
