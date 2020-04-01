using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    public interface IDetalleFacturaServices
    {
        //Servicios para los detalles de facturas
        DetalleFacturaEnt GetDetalleFactura(int IdDetalle);
        string UpdateDetalleFact(int IdDetalle, DetalleFacturaEnt detToUp);
        //IEnumerable<DetalleFacturaEnt> TodosLosDetalles();
        IEnumerable<DetalleFacturaEnt> TodosLosDetallesByCS(string Correlativo, string Serie);
        string NuevoDetalle(DetalleFacturaEnt nuevoDetalleFact);
    }
}
