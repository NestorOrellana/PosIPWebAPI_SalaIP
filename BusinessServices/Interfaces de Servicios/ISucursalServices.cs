using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    public interface ISucursalServices
    {
        IEnumerable<SucursalEnt> GetAll();
        SucursalEnt GetSucursalById(short idSucursal);
        string CreateSucursal(SucursalEnt nuevaSucursal);
    }
}
