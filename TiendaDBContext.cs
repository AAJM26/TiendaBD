using Microsoft.EntityFrameworkCore;

namespace TiendaBD.Models
{
    public class TiendaDBContext : DbContext
    {
        // Constructor principal que recibe las opciones del contexto
        public TiendaDBContext(DbContextOptions<TiendaDBContext> options) : base(options)
        {
            Productos = Set<Producto>();
            Categorias = Set<Categoria>();// Inicializa Productos dentro del constructor principal
        }

        // Propiedad DbSet para Productos
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
