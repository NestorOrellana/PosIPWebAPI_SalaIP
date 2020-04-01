using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces_de_Servicios
{
    public interface ITrasladoFacturas
    {
        //Metodo de traslado de facturas de la interfaz.
        int TrasladoFacturas(DateTime fecha, int idSucursal, string usuario);
    }
}
