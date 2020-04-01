using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Transactions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class CajaChicaServices : ICajaChicaServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public CajaChicaServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Servicio que inserta un nuevo registro CajaChica en la bd
        public int CreateCajaChica(BusinessEntities.CajaChicaEnt nuevaCajaChica)
        {
            using (var scope = new TransactionScope())
            {
                var cajaChica = new CajaChica
                {
                    IdUsuario = nuevaCajaChica.IdUsuario,
                    IdSucursal = nuevaCajaChica.IdSucursal,
                    FECHA = nuevaCajaChica.FECHA,
                    MONTO = nuevaCajaChica.MONTO,
                    Estado = nuevaCajaChica.Estado,
                    IDCajaChica = nuevaCajaChica.IDCajaChica
                };
                _unitOfWork.RepositorioCajaChica.Insert(cajaChica);
                _unitOfWork.Save();
                scope.Complete();
                return cajaChica.IDCajaChica;
            }
        }

        //Retorna el registro de caja chica activo
        public BusinessEntities.CajaChicaEnt GetCajaWhere()
        {
            Func<CajaChica, Boolean> param = x => { if (x.Estado == true) return true; else return false; };
            var cajaChica = _unitOfWork.RepositorioCajaChica.Get(param);
            if (cajaChica != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CajaChica, BusinessEntities.CajaChicaEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloCaja = mapper.Map<CajaChica, BusinessEntities.CajaChicaEnt>(cajaChica);
                return modeloCaja;
            }
            return null;
        }
    }
}
