using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ViewPluEnt
    {
        public long IdPLU { get; set; }
        public long IdReceta { get; set; }
        public string Descripcion { get; set; }
        public decimal? precio { get; set; }
        public short IdCategoria { get; set; }
        public short IdSucursal { get; set; }
        public long CodigoSAP { get; set; }
        public byte IdUnidadVenta { get; set; }
        public bool IdEstado { get; set; }
        public bool SeDetalla { get; set; }
        public string ListaPrecio { get; set; }
    }
}
