using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    //Procedimiento almacenado que retorna el pedido a entregar el dia actual.
    public class SPGetPedidosEnt
    {
        public long IdPedido { get; set; }
        public string FechaEntrega { get; set; }
        public long? IdProductos { get; set; }
        public decimal? UnidadesPedido { get; set; }
        public decimal? PesoPedido { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public long? NumeroLinea { get; set; }
        public int? UnidadFacturacion { get; set; }
    }
}
