using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTienda.Business.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Valor { get; set; }
        public string url { get; set; }
    }
}
