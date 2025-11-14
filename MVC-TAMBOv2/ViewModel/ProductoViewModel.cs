using System.ComponentModel.DataAnnotations;

namespace MVC_TAMBOv2.ViewModel
{
    public class ProductoViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La fecha de expiración es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime FechaExpiracion { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public string Categoria { get; set; }
    }
}
