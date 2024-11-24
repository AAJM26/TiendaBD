using System.ComponentModel.DataAnnotations;

namespace TiendaBD.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string? Nombre { get; set; }


        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un número no negativo")]
        public int Stock { get; set; }

        public int CategoriaPId { get; set; }

        virtual public Categoria? CategoriaP { get; set; }
    }
}
