
using TiendaBD.Models;

namespace TiendaBD.Repositorio
{
    public interface IRepositorioCategorias
    {
        Task<List<Categoria>> GetAll();               // Obtener todas las categorías
        Task<Categoria?> Get(int id);                  // Obtener una categoría por ID
        Task<Categoria> Add(Categoria categoria);      // Agregar una nueva categoría
        Task<Categoria?> Update(int id, Categoria categoria); // Actualizar una categoría por ID
        Task Delete(int id);                           // Eliminar una categoría por ID
    }
}
