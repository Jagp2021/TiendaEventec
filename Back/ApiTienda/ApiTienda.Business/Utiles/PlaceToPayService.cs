using ApiTienda.Business.DTO.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiTienda.Business.Utiles
{
    public class PlaceToPayService
    {
        public PaymentResponseDTO StartSession(PaymentRequestDTO request)
        {
            var auth = new Authentication();
            request.auth = auth.Auth;
            var x = JsonConvert.SerializeObject(auth.Auth);
            request.locale = "es_CO";
            request.expiration = Utiles.generateExpirationDate();
            request.userAgent = "PlacetoPay Sandbox";
            request.ipAddress = "::1";
            var client = new HttpClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = client.PostAsync(Settings.Default.UrlPaymentService, httpContent).Result;
            var json = JsonConvert.DeserializeObject<PaymentResponseDTO>(response.Content.ReadAsStringAsync().Result);
            return json;
        }

        public object SearchSession(int id)
        {
            var auth = new Authentication();
            dynamic body = new { auth = auth.Auth };
            var client = new HttpClient();
            var content = JsonConvert.SerializeObject(body);
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            var url = string.Format("{0}{1}", Settings.Default.UrlSearchPayment, id);
            var response = client.PostAsync(url, httpContent).Result;
            var json = JsonConvert.DeserializeObject<object>(response.Content.ReadAsStringAsync().Result);
            return json;
        }
    }
}
