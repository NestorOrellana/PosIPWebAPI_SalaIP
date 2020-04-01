using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    //Entidad Receta
    public class RecetaEnt
    {
        public long IdReceta { get; set; }
        public long IdProducto { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public short IdSucursal { get; set; }
    }
}
