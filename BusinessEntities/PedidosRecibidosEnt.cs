using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PedidosRecibidosEnt
    {
        public long IdRegistro { get; set; }
        public short IdSucursal { get; set; }
        public long IdProducto { get; set; }
        public DateTime FechaEntrega { get; set; }
        public double CantidadEnviada { get; set; }
        public double CantidadConfirmada { get; set; }
        public byte Estado { get; set; }
        public long IdPedido { get; set; }

        public PedidosRecibidosEnt()
        {

        }
    }
}
