using System.ComponentModel.DataAnnotations;

namespace TiendaBD.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es requerido")]
        [StringLength(100, ErrorMessage = "El nombre de la categoría debe tener un máximo de 100 caracteres")]
        public string? Nombre { get; set; }

        // Relación inversa: un conjunto de productos asociados a esta categoría
        public virtual ICollection<Producto>? Producto { get; set; }
    }
}
