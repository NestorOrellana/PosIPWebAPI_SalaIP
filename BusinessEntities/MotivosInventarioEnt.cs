using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    //Entidad Motivos de movimientos de inventario
    public class MotivosInventarioEnt
    {
        public int IdMotivo { get; set; }
        public string Descripcion { get; set; }
        public short Estado { get; set; }
    }
}
