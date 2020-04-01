using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices
{
    public class EncabezadoFacturaServices : IEncabezadoFacturaServices
    {
        private readonly UnitOfWork _unitOfWork;

        public EncabezadoFacturaServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Retorna un listado con todos los Encabezados de todas las sucursales en la bd
        public IEnumerable<BusinessEntities.FacturaEEnt> TodosLosEncabezados()
        {
            var listEncabezados = _unitOfWork.RepositorioFacturaE.GetAll().ToList();
            if (listEncabezados.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<FacturaE, BusinessEntities.FacturaEEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloEncabezado = mapper.Map<List<FacturaE>, List<BusinessEntities.FacturaEEnt>>(listEncabezados);
                return modeloEncabezado;
            }
            return null;
        }

        public void DeleteFactura(string Correlativo, string Serie)
        {
            Func<FacturaE, Boolean> param = x => { if (x.Correlativo == Correlativo && x.NumeroSerie == Serie) return true; else return false; };
            _unitOfWork.RepositorioFacturaE.Delete(param);
        }

        //Retorna un encabezado de factura en especifico registrado en la bd 
        public BusinessEntities.FacturaEEnt GetFacturaE(string Correlativo, string NumeroSerie)
        {
            Func<FacturaE, Boolean> param = x => { if (x.Correlativo == Correlativo && x.NumeroSerie == NumeroSerie) return true; else return false; };
            var encabezado = _unitOfWork.RepositorioFacturaE.Get(param);
            if (encabezado != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<FacturaE, BusinessEntities.FacturaEEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloEncabezado = mapper.Map<FacturaE, BusinessEntities.FacturaEEnt>(encabezado);
                return modeloEncabezado;
            }
            return null;
        }

        //Servicio que registra un nuevo encabezado de factura en la bd
        public string CreateFacturaE(BusinessEntities.FacturaEEnt nuevoEncabezado)
        {
            using (var scope = new TransactionScope())
            {
                var encabezado = new FacturaE
                {
                    NumeroSerie = nuevoEncabezado.NumeroSerie,
                    Correlativo = nuevoEncabezado.Correlativo,
                    FechaHora = nuevoEncabezado.FechaHora,
                    IdSucursal = nuevoEncabezado.IdSucursal,
                    Nit = nuevoEncabezado.Nit,
                    Total = nuevoEncabezado.Total,
                    Estado = nuevoEncabezado.Estado,
                    Nombre = nuevoEncabezado.Nombre,
                    Direccion = nuevoEncabezado.Direccion
                };
                _unitOfWork.RepositorioFacturaE.Insert(encabezado);
                _unitOfWork.Save();
                scope.Complete();
                return "Encabezado de factura registrado exitosamente!";
            }
        }

        //Metodo que modifica un Encabezado de Factura en especifico
        public string UpdateFacturaE(string Correlativo, string NumeroSerie, BusinessEntities.FacturaEEnt  encabezadoToUp)
        {
            using (var scope = new TransactionScope())
            {
                Func<FacturaE, Boolean> param = x => { if (x.Correlativo == Correlativo && x.NumeroSerie == NumeroSerie) return true; else return false; };

                var encabezado = _unitOfWork.RepositorioFacturaE.Get(param);
                if (encabezado != null)
                {
                    encabezado.Correlativo = encabezadoToUp.Correlativo;
                    encabezado.NumeroSerie = encabezadoToUp.NumeroSerie;
                    encabezado.Nit = encabezadoToUp.Nit;
                    encabezado.IdSucursal = encabezadoToUp.IdSucursal;
                    encabezado.FechaHora = encabezadoToUp.FechaHora;
                    encabezado.Total = encabezadoToUp.Total;
                    encabezado.Estado = encabezadoToUp.Estado;
                    encabezado.Nombre = encabezado.Nombre;

                    _unitOfWork.RepositorioFacturaE.Update(encabezado);
                    _unitOfWork.Save();
                    scope.Complete();

                    return "Motivo modificado exitosamente!";
                }
                else
                    return "El Motivo indicado no se encuentra registrado, por favor vuelva a intentarlo.";
            }
        }
    }
}
