using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class MovimientoInventarioEnt
    {
        public long IdMovimientoInventario { get; set; }
        public long IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal CantidadEntrada { get; set; }
        public decimal Salida { get; set; }
        public decimal Ajustes { get; set; }
        public decimal SaldoFinal { get; set; }
        public short IdSucursal { get; set; }
        public DateTime FechaHoraMovimiento { get; set; }
        public short IdTipoMovimiento { get; set; }

        public MovimientoInventarioEnt()
        {

        }
    }
}
