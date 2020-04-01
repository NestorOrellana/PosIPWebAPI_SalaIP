using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface ISPGetPedidosServices
    {
        //interfaz que define los servicios de pedios
        List<SPGetPedidosEnt> GetPedido(long codigoUsuario);
    }
}