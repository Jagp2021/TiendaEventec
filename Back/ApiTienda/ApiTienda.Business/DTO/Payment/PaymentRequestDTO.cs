using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTienda.Business.DTO.Payment
{
    public class PaymentRequestDTO
    {
        public AuthDTO auth { get; set; }
        public string locale { get; set; }
        public BuyerDTO buyer { get; set; }
        public PaymentDTO payment { get; set; }
        public string expiration { get; set; }
        public string returnUrl { get; set; }
        public string userAgent { get; set; }
        public string ipAddress { get; set; }
    }
}
