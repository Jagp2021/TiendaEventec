using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ApiTienda.Business.Utiles;
using ApiTienda.Business.DTO.Payment;

namespace WebApplication2.Controllers
{
    public class PlacetoPayController : ApiController
    {
        PlaceToPayService service = new PlaceToPayService();
        Authentication auth = new Authentication();
        [HttpPost]
        public JsonResult<PaymentResponseDTO> StartSession(PaymentRequestDTO request)
        {
            var result = service.StartSession(request);
            return Json(result);
        }

        [HttpGet]
        public JsonResult<object> SearchTransaction(int id)
        {
            var result = service.SearchSession(id);
            return Json(result);
        }

        [HttpGet]
        public JsonResult<AuthDTO> GetAuth()
        {
            var authres = auth.Auth;
            return Json(authres);
        }
    }
}