using Libreria.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libreria.Repositorios
{
    public class RepositorioLibros : IRepositorioLibros
    {
        private readonly BDLibreriaDBContext _context;

        public RepositorioLibros(BDLibreriaDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Libro>> ObtenerTodosAsync()
        {
            return await _context.Libros.ToListAsync();
        }

        public async Task<Libro?> ObtenerPorIdAsync(int id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public async Task AgregarAsync(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Libro libro)
        {
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
                throw new Exception("Libro no encontrado");

            if (libro.Cantidad > 0)
                throw new Exception("No se puede eliminar un libro con unidades en stock");

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();
        }

    }
}
