using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    //Entidad Usuario
    public class UsuarioEnt
    {
        public short PIN { get; set; }
        public short IdSucursal { get; set; }
        /// <summary>
        /// 20 = administrativo, 21 = operador
        /// </summary>
        public short IdTipoUsuario { get; set; }
        public bool Estado { get; set; }
        public string Nombre { get; set; }
        public long IdUsuario { get; set; }
        public string Usuario { get; set; }
    }
}
