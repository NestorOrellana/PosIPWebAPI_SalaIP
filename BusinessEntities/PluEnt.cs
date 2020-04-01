using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PluEnt
    {
        public long IdReceta { get; set; }
        public string Descripcion { get; set; }
        public decimal precio { get; set; }
        public short IdUnidadVenta { get; set; }
        public short IdCategoria { get; set; }
        public short? IdSucursal { get; set; }
        public byte IdEstado { get; set; }
        public long? CodigoSAP { get; set; }
        public long IdPLU { get; set; }
        public long IdProducto { get; set; }
    }
}
