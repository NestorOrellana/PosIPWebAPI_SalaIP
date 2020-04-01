using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    public interface IEncabezadoFacturaServices
    {
        //Servicios para encabezados de factura
        FacturaEEnt GetFacturaE(string Correlativo, string NumeroSerie);
        string UpdateFacturaE(string Correlativo, string NumeroSerie, FacturaEEnt encabezadoToUp);
        IEnumerable<FacturaEEnt> TodosLosEncabezados();
        string CreateFacturaE(FacturaEEnt nuevoEncabezado);
        void DeleteFactura(string Correlativo, string Serie);
    }
}
