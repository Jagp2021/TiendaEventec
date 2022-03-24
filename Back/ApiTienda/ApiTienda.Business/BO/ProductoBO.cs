namespace ApiTienda.Business.BO
{
    #region Librerias
    using ApiTienda.Business.DTO;
    using ApiTienda.Data.Dao;
    using ApiTienda.Data.Entities;
    using AutoMapper;
    using System.Collections.Generic;
    #endregion
    public class ProductoBO
    {
        #region Variables y Propiedades
        MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<Producto, ProductoDTO>()
                                    .ForMember( dest => dest.IdProducto, act => act.MapFrom(src => src.IdProducto))
                                    .ForMember(dest => dest.NombreProducto, act => act.MapFrom(src => src.NombreProducto))
                                    .ForMember(dest => dest.Valor, act => act.MapFrom(src => src.Valor))
        );
        ProductoDao dataAccess = new ProductoDao();
        #endregion

        #region Métodos y Funciones
        public List<ProductoDTO> getProducts()
        {
            var mapper = new Mapper(config);
            return mapper.Map<List<ProductoDTO>>(dataAccess.getList());
        }
        #endregion
    }
}
