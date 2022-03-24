namespace ApiTienda.Data.Dao
{
    #region Librerias
    using ApiTienda.Data.Context;
    using ApiTienda.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    #endregion
    public class OrdenDao
    {
        #region Métodos y Funciones
        /// <summary>
        /// Obtiene el Listado de Todas las ordenes de la tienda
        /// </summary>
        /// <returns></returns>
        public List<Orden> getList()
        {
            List<Orden> list = new List<Orden>();
            try
            {
                using( var context = new TiendaEntities())
                {
                    list = context.Orden.Select(x => x).Include(x => x.DetalleOrden).ToList(); ;
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Obtiene todas las ordenes asociadas a un usuario
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<Orden> getListByEmail(string email)
        {
            List<Orden> list = new List<Orden>();
            try
            {
                using (var context = new TiendaEntities())
                {
                    list = context.Orden.Where(x => x.CustomerEmail == email.ToLower()).Include(x => x.DetalleOrden).ToList(); ;
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Obtiene todas una orden por id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Orden getListById(int id)
        {
            Orden orden = new Orden();
            try
            {
                using (var context = new TiendaEntities())
                {
                    orden = context.Orden.Where(x => x.Id == id).Include(x => x.DetalleOrden).SingleOrDefault(); ;
                }
                return orden;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Guarda o modifica una orden
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Orden saveOrden (Orden model)
        {
            Orden result = new Orden();
            try
            {
                using (var context = new TiendaEntities())
                {

                    if (model.Id == 0)
                    {
                        context.Orden.Add(model);
                        result = model;
                    } else
                    {
                        var entity = context.Orden.FirstOrDefault(x => x.Id == model.Id);
                        entity.Status = model.Status;
                        entity.UpdateAt = model.UpdateAt;
                        entity.TransactionId = model.TransactionId;
                        result = entity;
                    }

                    context.SaveChanges();
                    return model;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
