using Microsoft.EntityFrameworkCore;
using TiendaBD.Models;

namespace TiendaBD.Repositorio
{
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly TiendaDBContext _context;

        // Constructor que recibe el contexto de la base de datos
        public RepositorioCategorias(TiendaDBContext context)
        {
            _context = context;
        }

        // Obtener todas las categorías
        public async Task<List<Categoria>> GetAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        // Obtener una categoría por su ID
        public async Task<Categoria?> Get(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        // Agregar una nueva categoría
        public async Task<Categoria> Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        // Actualizar una categoría existente
        public async Task<Categoria?> Update(int id, Categoria categoria)
        {
            var categoriaExistente = await _context.Categorias.FindAsync(id);
            if (categoriaExistente != null)
            {
                categoriaExistente.Nombre = categoria.Nombre; // Actualizar solo los campos necesarios
                await _context.SaveChangesAsync();
                return categoriaExistente;
            }
            return null; // Retorna null si la categoría no se encuentra
        }

        public async Task Delete(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
