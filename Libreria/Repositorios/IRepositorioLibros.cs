using System.Collections.Generic;
using System.Threading.Tasks;
using Libreria.Data;

namespace Libreria.Repositorios
{
    public interface IRepositorioLibros
    {
        Task<IEnumerable<Libro>> ObtenerTodosAsync();
        Task<Libro?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Libro libro);
        Task ActualizarAsync(Libro libro);
        Task EliminarAsync(int id);
    }
}
