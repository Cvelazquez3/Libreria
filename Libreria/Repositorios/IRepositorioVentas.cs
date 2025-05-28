using System.Collections.Generic;
using System.Threading.Tasks;
using Libreria.Data;

namespace Libreria.Repositorios
{
    public interface IRepositorioVentas
    {
        Task<IEnumerable<Venta>> ObtenerTodosAsync();
        Task<Venta?> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Venta venta);
        Task ActualizarAsync(Venta venta);
        Task EliminarAsync(int id);
    }
}
