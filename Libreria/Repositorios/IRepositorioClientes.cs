using Libreria.Data;

public interface IRepositorioClientes
{
    Task<List<Cliente>> ObtenerTodosAsync();
    Task<Cliente?> ObtenerPorIdAsync(int id);
    Task AgregarAsync(Cliente cliente); // 👈 ESTE MÉTODO ES NECESARIO
    Task ActualizarAsync(Cliente cliente);
    Task EliminarAsync(int id);
}
