using AutoMapper;
using BusinessEntities;
using BusinessServices.Interfaces_de_Servicios;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessServices.Servicios
{
    public class MovimientoInventarioServices : IMovimientoInventario
    {
        private readonly UnitOfWork _unitOfWork;

        public MovimientoInventarioServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public long RegistrarMovimientoInventario(MovimientoInventarioEnt nuevoMovimiento)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                MapperConfiguration config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MovimientoInventarioEnt, MovimientoInventario>();
                });

                IMapper mapper = config.CreateMapper();
                MovimientoInventario movimientoInventario = mapper.Map<MovimientoInventarioEnt, MovimientoInventario>(nuevoMovimiento);

                _unitOfWork.RepositorioMovimientoInventario.Insert(movimientoInventario);
                _unitOfWork.Save();
                transaction.Complete();

                return movimientoInventario.IdMovimientoInventario;
            }
        }

        public ResponseObject RegistrarMovimientosDelDia(List<MovimientoInventarioEnt> movimientosDelDia)
        {
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    MapperConfiguration config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<MovimientoInventarioEnt, MovimientoInventario>();
                    });

                    IMapper mapper = config.CreateMapper();
                    List<MovimientoInventario> movimientosInventario = mapper.Map<List<MovimientoInventarioEnt>, List<MovimientoInventario>>(movimientosDelDia);

                    _unitOfWork.RepositorioMovimientoInventario.InsertCollection(movimientosInventario);
                    _unitOfWork.Save();
                    transaction.Complete();
                    ResponseObject response = new ResponseObject()
                    {
                        Response = null,
                        ResponseMessage = "Movimientos del dia registrados exitosamente",
                        Result = true
                    };

                    return response;
                }
            }
            catch (Exception ex)
            {
                ResponseObject response = new ResponseObject()
                {
                    Response = null,
                    ResponseMessage = ex.Message,
                    Result = false
                };
                return response;
            }
        }
        
    }
}
