using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductosCRUD.Client.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }

        public int Talla { get; set; }

        public string Color { get; set; } = null!;

        public decimal Precio { get; set; }

        public string Descripcion { get; set; } = null!;
    }
}