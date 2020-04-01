using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces_de_Servicios
{
    public interface IConversionesProductos
    {
        IEnumerable<ConversionesProductosEnt> TodasLasConversiones();
        ConversionesProductosEnt ConversionPorId(int idConversion);
        string ModificarConversion(int idConversion, ConversionesProductosEnt conversion);
        string CrearConversion(ConversionesProductosEnt nuevaConversion);
    }
}
