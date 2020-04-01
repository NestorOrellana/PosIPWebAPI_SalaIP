using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    //Entidad para la tabla de conversiones de los pedidos retornados en el procedimiento almacenado.
    public class ConversionesProductosEnt
    {
        public int IdConversion { get; set; }
        public long IdProductoSAP { get; set; }
        public double? Cantidad { get; set; }
        public long? IdProductoDestino { get; set; }
    }
}