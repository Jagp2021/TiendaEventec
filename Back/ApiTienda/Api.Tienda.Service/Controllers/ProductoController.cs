using ApiTienda.Business.BO;
using ApiTienda.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApplication2.Controllers
{
    public class ProductoController : ApiController
    {
        ProductoBO productoBO = new ProductoBO();
        public JsonResult<List<ProductoDTO>> Get()
        {
            var list = productoBO.getProducts();
            return Json(list);
        }
    }
}