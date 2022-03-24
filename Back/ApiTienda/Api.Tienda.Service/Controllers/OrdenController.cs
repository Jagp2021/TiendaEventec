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
    public class OrdenController : ApiController
    {
        OrdenBO ordenBO = new OrdenBO();

        [HttpGet]
        public JsonResult<List<OrdenDTO>> Get()
        {
            var list = ordenBO.getOrdenes();
            return Json(list);
        }

        [HttpGet]
        public JsonResult<List<OrdenDTO>> GetByEmail(string email)
        {
            var list = ordenBO.getOrdenesByEmail(email);
            return Json(list);
        }

        [HttpGet]
        public JsonResult<OrdenDTO> GetById(int id)
        {
            var orden = ordenBO.getOrdenesById(id);
            return Json(orden);
        }

        [HttpPost]
        public JsonResult<OrdenDTO> SaveOrden(OrdenDTO orden)
        {
            var ordenResult = ordenBO.saveOrdenes(orden);
            return Json(ordenResult);
        }
    }
}