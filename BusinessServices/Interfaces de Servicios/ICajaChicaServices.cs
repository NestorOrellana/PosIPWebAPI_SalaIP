using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    //interfaz de los servicios para caja chica
    public interface ICajaChicaServices
    {
        //CajaChicaEnt GetCajaChicaWhere();
        int CreateCajaChica(CajaChicaEnt nuevaCajaChica);
        CajaChicaEnt GetCajaWhere();
    }
}
