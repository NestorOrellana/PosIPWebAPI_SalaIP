using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces_de_Servicios
{
    public interface ISPUpdateCorrelativo
    {
        //interfaz que define los servicios de pedios
        int UpdateCorrelativo(string numeroSerie, int idSucursal, long codigoUsuario, long numeroDel, long numeroAl, short idSerie);
    }
}
