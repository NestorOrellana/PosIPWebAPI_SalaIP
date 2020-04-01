using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    //interfaz de servico de PLU
    public interface IPluServices
    {
        //Servicios de Plu
        PluEnt GetPluById(int plu);
        string UpdatePlu(int idPlu, PluEnt pluToUpdate);
        IEnumerable<PluEnt> GetAllPlu();
        string CreatePlu(PluEnt nuevoPlu);
        IEnumerable<PluEnt> GetPluPorSucursal(int idSucursal);
    }
}
