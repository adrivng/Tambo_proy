namespace MVC_TAMBOv2.ViewModel
{
    public class ProductoViewModel
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string Marca { get; set; }       // cadena digitada por el usuario
        public string Categoria { get; set; }   // cadena digitada por el usuario
    }
}
