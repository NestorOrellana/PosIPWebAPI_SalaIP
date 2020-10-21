using DataModel;
using DataModel.UnitOfWork;
using BusinessServices.Interfaces_de_Servicios;

namespace BusinessServices.Servicios
{
    public class SPUpdateCorrelativo : ISPUpdateCorrelativo
    {
        private readonly UnitOfWork _unitOfWork;

        public SPUpdateCorrelativo(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Retorna una lista de productos registrados filtrados por Categoria
        public int UpdateCorrelativo(string numeroSerie,int idSucursal, long correlativo, long numeroDel, long numeroAl, short idSerie)
        {
            //var context = new ComercializacionDIPEntities();
            int pedido = 1;
            /*if(correlativo == numeroAl)
            {
                pedido = context.SPUpdateCorrelativo(numeroSerie, idSucursal, correlativo - 1, idSerie);
                pedido = 1;
            }
            else if ((correlativo + 1) <= numeroAl)
            {
                pedido = context.SPUpdateCorrelativo(numeroSerie, idSucursal, correlativo, idSerie);
                pedido = 1;
            }
            else
            {
                context.SPInactivarCorrelativo(numeroSerie, idSucursal);
                pedido = 2;
            }*/
            return pedido;
        }
    }
}
