using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class RegistroSincEnt
    {
        public long IdRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        //1 = Sincronizacion Diaria ; 2 = Cierre del Dia
        public short Operacion { get; set; }
        public short IdSucursal { get; set; }
    }
}
