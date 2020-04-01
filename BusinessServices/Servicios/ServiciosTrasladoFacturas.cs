using BusinessServices.Interfaces_de_Servicios;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Servicios
{
    public class ServiciosTrasladoFacturas : ITrasladoFacturas
    {
        private readonly UnitOfWork _unitOfWork;

        public ServiciosTrasladoFacturas(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Funcion que traslada las facturas registradas con la fecha indicada a la intermedia.
        public int TrasladoFacturas(DateTime fecha, int idSucursal, string usuario)
        {
            var context = new ComercializacionDIPEntities();
            var traslado = context.TrasladoFacturas(fecha, idSucursal, usuario);
            return traslado;
        }
    }
}
