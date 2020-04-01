using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    //Servivios de los numeros de serie de las facturas
    public interface ISFactServices
    {
        //ViewFacturaSerieEnt GetFactS(int IdSerie);
        string UpdateFactS(short IdSerie, short IdSucursal);
        ViewFacturaSerieEnt GetFactSBySucursal(int IdSucural);
        IEnumerable<ViewFacturaSerieEnt> GetSeriesBySucursal(int IdSucursal);
    }
}
