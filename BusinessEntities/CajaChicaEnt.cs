using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CajaChicaEnt
    {
        public short IdUsuario { get; set; }
        public short IdSucursal { get; set; }
        public System.DateTime FECHA { get; set; }
        public decimal MONTO { get; set; }
        public bool Estado { get; set; }
        public int IDCajaChica { get; set; }

        //public virtual SucursalEnt Sucursal { get; set; }
        //public virtual SucursalEnt Usuarios { get; set; }
        public CajaChicaEnt()
        {

        }
    }
}
