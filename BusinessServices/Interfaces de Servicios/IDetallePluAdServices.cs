using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    public interface IDetallePluAdServices
    {
        //Servicios para los detalles de los plus adquiridos
        DetallePluAdquiridoEnt GetPluDetalle(int idDetalle);
        string UpdatePluDet(int idDetalle, DetallePluAdquiridoEnt detToUpdate);
        //IEnumerable<DetallePluAdquiridoEnt> TodosLosDetalles();
        IEnumerable<DetallePluAdquiridoEnt> GetDetallesByIdFact(int idDetalleFactura);
        string CreateDetalle(DetallePluAdquiridoEnt nuevoDetalle);
    }
}
