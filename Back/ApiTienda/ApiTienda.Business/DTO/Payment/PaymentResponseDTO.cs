using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTienda.Business.DTO.Payment
{
    public class PaymentResponseDTO
    {
        public StatusDTO status { get; set; }
        public long requestId { get; set; }
        public string processUrl { get; set; }
    }

    public class StatusDTO
    {
        public string status { get; set; }
        public string reason { get; set; }
        public string message { get; set; }
        public string date { get; set; }
    }
}
