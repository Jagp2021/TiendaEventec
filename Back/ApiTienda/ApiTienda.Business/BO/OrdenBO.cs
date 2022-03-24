namespace ApiTienda.Business.BO
{
    #region Librerias
    using System.Collections.Generic;
    using ApiTienda.Business.DTO;
    using ApiTienda.Data.Dao;
    using ApiTienda.Data.Entities;
    using AutoMapper;
    #endregion
    public class OrdenBO
    {
        #region Variables y Propiedades
        MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Orden, OrdenDTO>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerName, act => act.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.CustomerEmail, act => act.MapFrom(src => src.CustomerEmail))
                .ForMember(dest => dest.CustomerMobile, act => act.MapFrom(src => src.CustomerMobile))
                .ForMember(dest => dest.Status, act => act.MapFrom(src => src.Status))
                .ForMember(dest => dest.TransactionId, act => act.MapFrom(src => src.TransactionId))
                .ForMember(dest => dest.CreateAt, act => act.MapFrom(src => src.CreateAt))
                .ForMember(dest => dest.UpdateAt, act => act.MapFrom(src => src.UpdateAt));
            cfg.CreateMap<DetalleOrden, DetalleOrdenDTO>();
            cfg.CreateMap<DetalleOrdenDTO, DetalleOrden>();
            cfg.CreateMap<OrdenDTO, Orden>();
        }

        );

        OrdenDao dataAccessOrden = new OrdenDao();
        DetalleOrdenDao dataAccessDetalleOrden = new DetalleOrdenDao();
        #endregion

        #region Métodos y Funciones
        /// <summary>
        /// Consultar Listado de todas las ordenes
        /// </summary>
        /// <returns></returns>
        public List<OrdenDTO> getOrdenes()
        {
            var mapper = new Mapper(config);
            return mapper.Map<List<OrdenDTO>>(dataAccessOrden.getList());
        }

        /// <summary>
        /// Consultar Ordenes por email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<OrdenDTO> getOrdenesByEmail(string email)
        {
            var mapper = new Mapper(config);
            return mapper.Map<List<OrdenDTO>>(dataAccessOrden.getListByEmail(email));
        }

        // <summary>
        /// Consultar Ordenes por id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public OrdenDTO getOrdenesById(int id)
        {
            var mapper = new Mapper(config);
            return mapper.Map<OrdenDTO>(dataAccessOrden.getListById(id));
        }

        /// <summary>
        /// Guardar o modificar ordenes
        /// </summary>
        /// <param name="ordenDTO"></param>
        /// <returns></returns>
        public OrdenDTO saveOrdenes(OrdenDTO ordenDTO)
        {
            var mapper = new Mapper(config);
            Orden model = mapper.Map<Orden>(ordenDTO);
            var orden =dataAccessOrden.saveOrden(model);
            return mapper.Map<OrdenDTO>(orden);
        }
        #endregion
    }
}
