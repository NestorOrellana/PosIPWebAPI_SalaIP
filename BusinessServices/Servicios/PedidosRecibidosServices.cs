using BusinessEntities;
using BusinessServices.Interfaces_de_Servicios;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Servicios
{
    public class PedidosRecibidosServices : IPedidosRecibidosServices
    {
        private readonly UnitOfWork _unitOfWork;

        public PedidosRecibidosServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ResponseObject RegistrarPedidoRecibido(IEnumerable<PedidosRecibidosEnt> detallesPedido)
        {
            //_unitOfWork.RepositorioPedidosRecibidos.InsertCollection(detallesPedido);
            return null;
        }
    }
}
