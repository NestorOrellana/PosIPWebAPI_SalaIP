using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ViewRecetaEnt
    {
        public long IdReceta { get; set; }
        public long IdProducto { get; set; }
        public decimal precio { get; set; }
        public decimal cantidad { get; set; }
        public short IdSucursal { get; set; }
    }
}
