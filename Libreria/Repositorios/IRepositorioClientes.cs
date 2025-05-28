using System.Collections.Generic;
using System.Threading.Tasks;
using Libreria.Data;

namespace Libreria.Repositorios
{
    public interface IRepositorioClientes
    {
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Cliente cliente);
        Task ActualizarAsync(Cliente cliente);
        Task EliminarAsync(int id);
    }
}
