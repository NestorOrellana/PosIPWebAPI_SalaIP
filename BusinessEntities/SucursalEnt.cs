using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    //Entidad Sucursal
    public class SucursalEnt
    {
        public short IdSucursal { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public long CentroSAP { get; set; }
        public int OficinaVenta { get; set; }
        public long IdEstablecimiento { get; set; }
        public long CodigoCliente { get; set; }
    }
}
