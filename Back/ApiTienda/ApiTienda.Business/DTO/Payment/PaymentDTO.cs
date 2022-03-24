using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTienda.Business.DTO.Payment
{
    public class PaymentDTO
    {
        public string reference { get; set; }
        public string description { get; set; }
        public AmountDTO amount { get; set; }
        public bool allowpartial { get; set; }
    }

    public class AmountDTO
    {
        public string currency { get; set; }
        public decimal total { get; set; }
    }
}
