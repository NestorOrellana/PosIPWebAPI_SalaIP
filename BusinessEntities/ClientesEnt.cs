using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ClientesEnt
    {
        public long IdCliente { get; set; }
        public string Nombre1 { get; set; }
        public string NombreNegocio { get; set; }
        public decimal LimiteCredito { get; set; }
        public decimal SaldoCredito { get; set; }
        public string CodigoCondicionPago { get; set; }
        public short DiasCredito { get; set; }
        public string IdFiscal1 { get; set; }
        public string CodigoListaPrecios { get; set; }
        public string DirCalle1 { get; set; }

        public ClientesEnt()
        {

        }
    }
}
