using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    //Entidad Producto
    public class ProductEnt
    {
        public string NombreCompleto { get; set; }
        public byte UnidadMedida { get; set; }
        public short IdCategoria { get; set; }
        public decimal Precio { get; set; }
        /// <summary>
        /// Tipo == 1 Producto de SAP, Tipo == 2 Producto de Sucursal
        /// </summary>
        public byte Tipo { get; set; }
        public long CodigoSAP { get; set; }
        public long IdProducto { get; set; }
        public bool EsServicio { get; set; }
    }
}
