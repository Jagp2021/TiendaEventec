namespace ApiTienda.Data.Dao
{
    #region Librerias
    using ApiTienda.Data.Context;
    using ApiTienda.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    #endregion
    public class ProductoDao
    {
        #region Métodos y Funciones
        /// <summary>
        /// Obtiene el Listado de Productos
        /// </summary>
        /// <returns></returns>
        public List<Producto> getList()
        {
            List<Producto> list = new List<Producto>();
            try
            {
                using(var context = new TiendaEntities())
                {
                    list = context.Producto.ToList();
                    
                }

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
