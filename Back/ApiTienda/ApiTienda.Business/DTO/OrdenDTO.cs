namespace ApiTienda.Business.DTO
{
    #region Librerias
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    #endregion
    public class OrdenDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerMobile { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string TransactionId { get; set; }
        public  ICollection<DetalleOrdenDTO> DetalleOrden { get; set; }
    }
}
