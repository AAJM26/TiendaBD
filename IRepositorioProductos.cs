using Microsoft.EntityFrameworkCore;
using TiendaBD.Models;

namespace TiendaBD.Repositorio
{
    public class RepositorioProductos : IRepositorioProductos
    {
        private readonly TiendaDBContext _context;

        public RepositorioProductos(TiendaDBContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetAll()
        {
            return await _context.Productos
                                 .Include(p => p.CategoriaP)
                                 .ToListAsync();
        }

        public async Task<Producto> Add(Producto producto)
        {
            if (producto.CategoriaPId <= 0)
            {
                throw new ArgumentException("Debe seleccionar una categoría válida.");
            }

            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Producto?> Get(int id)
        {
            return await _context.Productos
                                 .Include(p => p.CategoriaP)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Producto?> Update(int id, Producto producto)
        {
            var existente = await _context.Productos.FindAsync(id);
            if (existente != null)
            {
                existente.Nombre = producto.Nombre;
                existente.CategoriaPId = producto.CategoriaPId; // Clave foránea
                existente.Precio = producto.Precio;
                existente.Stock = producto.Stock;

                await _context.SaveChangesAsync();
                return existente;
            }
            return null;
        }
    }
}
