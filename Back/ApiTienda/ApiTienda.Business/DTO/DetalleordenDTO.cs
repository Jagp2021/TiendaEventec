namespace ApiTienda.Business.DTO
{
    #region Librerias
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion
    public class DetalleOrdenDTO
    {
        public int IdDetalle { get; set; }

        public int IdOrden { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal Valor { get; set; }
    }
}
