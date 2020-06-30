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
    public class SucursalServices : ISucursalServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public SucursalServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Servicio que retorna todas las sucursales registradas en la bd.
        public IEnumerable<BusinessEntities.SucursalEnt> GetAll()
        {
            var sucursales = _unitOfWork.RepositorioSucursal.GetAll().ToList();
            if (sucursales.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Sucursal, BusinessEntities.SucursalEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloSucursal = mapper.Map<List<Sucursal>, List<BusinessEntities.SucursalEnt>>(sucursales);
                return modeloSucursal;
            }
            return null;
        }

        //Servicio que inserta un nuevo registro Sucursal en la bd
        public string CreateSucursal(BusinessEntities.SucursalEnt nuevaSucursal)
        {
            using (var scope = new TransactionScope())
            {
                var sucursal = new Sucursal
                {
                    IdSucursal = nuevaSucursal.IdSucursal,
                    Descripcion = nuevaSucursal.Descripcion,
                    CentroSAP = nuevaSucursal.CentroSAP,
                    Estado = nuevaSucursal.Estado,
                    OficinaVenta = nuevaSucursal.OficinaVenta,
                    IdEstablecimiento = nuevaSucursal.IdEstablecimiento,
                    CodigoCliente = nuevaSucursal.CodigoCliente
                };
                _unitOfWork.RepositorioSucursal.Insert(sucursal);
                _unitOfWork.Save();
                scope.Complete();
                return "Sucursal Registrada Exitosamente!";
            }
        }

        //Retorna una sucursal filtrado por su Id
        public BusinessEntities.SucursalEnt GetSucursalById(short idSucursal)
        {
            var sucursal = _unitOfWork.RepositorioSucursal.GetByID(idSucursal);
            if (sucursal != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Sucursal, BusinessEntities.SucursalEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloSucursal = mapper.Map<Sucursal, BusinessEntities.SucursalEnt>(sucursal);
                return modeloSucursal;
            }
            return null;
        }
    }
}
