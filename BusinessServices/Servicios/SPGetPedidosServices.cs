using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataModel.UnitOfWork;
using DataModel;

namespace BusinessServices
{
    public class SPGetPedidosServices : ISPGetPedidosServices
    {
        private readonly UnitOfWork _unitOfWork;

        public SPGetPedidosServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Retorna una lista de productos registrados filtrados por Categoria
        public List<BusinessEntities.SPGetPedidosEnt> GetPedido(long codigoUsuario)
        {
            var context = new ComercializacionDIPEntities();
            var pedido = context.WsGetPedidosHoyJSON(codigoUsuario).ToList();
            if (pedido.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<WsGetPedidosHoyJSON_Result1, BusinessEntities.SPGetPedidosEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloPedido = mapper.Map<List<WsGetPedidosHoyJSON_Result1>, List<BusinessEntities.SPGetPedidosEnt>>(pedido);
                return modeloPedido;
            }
            return null;
        }
    }
}