using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces_de_Servicios
{
    public interface IParametroServices
    {
        List<ParametrosEnt> GetParametros();
    }
}
