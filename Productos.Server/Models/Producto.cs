using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Productos.Server.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public int Talla { get; set; }

        public string Color { get; set; } = null!;
        
        public decimal Precio { get; set; }

        public string Descripcion { get; set; } = null!;
    }
}
