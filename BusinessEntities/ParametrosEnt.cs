using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ParametrosEnt
    {
        public int IdParametro { get; set; }
        public decimal MaximoPedido { get; set; }
        public bool AplicaRestriccion { get; set; }
    }
}
