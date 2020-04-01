using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface IMotivosInventarioServices
    {
        //Servicios para los motivos de movimientos de inventario
        MotivosInventarioEnt GetMotivoInventario(int idMotivo);
        string UpdateMotivo(int idMotivo, MotivosInventarioEnt pluToUpdate);
        IEnumerable<MotivosInventarioEnt> TodosLosMotivos();
        string CreateMotivo(MotivosInventarioEnt nuevoMotivo);
    }
}
