using AutoMapper;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessServices
{
    public class DetalleFacturaServices : IDetalleFacturaServices
    {
        private readonly UnitOfWork _unitOfWork;

        public DetalleFacturaServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Retorna un listado con todos los detalles de factura de una factura en especifico
        public IEnumerable<BusinessEntities.DetalleFacturaEnt> TodosLosDetallesByCS(string Correlativo, string Serie)
        {
            Func<DetalleFactura, Boolean> param = x => { if (x.NoCorrelativo == Correlativo && x.NoSerie == Serie) return true; else return false; };
            var listaDetalles = _unitOfWork.RepositorioDetalleFact.GetMany(param).ToList();
            if (listaDetalles.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DetalleFactura, BusinessEntities.DetalleFacturaEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloDetalle = mapper.Map<List<DetalleFactura>, List<BusinessEntities.DetalleFacturaEnt>>(listaDetalles);
                return modeloDetalle;
            }
            return null;
        }

        //Retorna un encabezado de factura en especifico registrado en la bd 
        public BusinessEntities.DetalleFacturaEnt GetDetalleFactura(int IdDetalle)
        {
            Func<DetalleFactura, Boolean> param = x => { if (x.IdDetalle == IdDetalle) return true; else return false; };
            var detalle = _unitOfWork.RepositorioDetalleFact.Get(param);
            if (detalle != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DetalleFactura, BusinessEntities.DetalleFacturaEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloDetalle = mapper.Map<DetalleFactura, BusinessEntities.DetalleFacturaEnt>(detalle);
                return modeloDetalle;
            }
            return null;
        }
        
        //Servicio que registra un nuevo detalle de factura en la bd
        public string NuevoDetalle(BusinessEntities.DetalleFacturaEnt nuevoDetalleFact)
        {
            using (var scope = new TransactionScope())
            {
                var detalle = new DetalleFactura
                {
                    Cantidad = nuevoDetalleFact.Cantidad,
                    NoCorrelativo = nuevoDetalleFact.NoCorrelativo,
                    NoSerie = nuevoDetalleFact.NoSerie,
                    SubTotal = nuevoDetalleFact.SubTotal,
                    IdPlu = nuevoDetalleFact.IdPlu,
                    PrecioPlu = nuevoDetalleFact.PrecioPlu,
                    UnidadMedida = nuevoDetalleFact.UnidadMedida
                };
                _unitOfWork.RepositorioDetalleFact.Insert(detalle);
                _unitOfWork.Save();
                scope.Complete();
                return "Detalle de factura registrado exitosamente!";
            }
        }

        //Metodo que modifica un Encabezado de Factura en especifico
        public string UpdateDetalleFact(int IdDetalle, BusinessEntities.DetalleFacturaEnt detToUp)
        {
            using (var scope = new TransactionScope())
            {
                Func<DetalleFactura, Boolean> param = x => { if (x.IdDetalle == IdDetalle) return true; else return false; };

                var detalle = _unitOfWork.RepositorioDetalleFact.Get(param);
                if (detalle != null)
                {
                    detalle.Cantidad = detToUp.Cantidad;
                    detalle.NoCorrelativo = detToUp.NoCorrelativo;
                    detalle.NoSerie = detToUp.NoSerie;
                    detalle.SubTotal = detToUp.SubTotal;
                    detalle.IdPlu = detToUp.IdPlu;
                    detalle.PrecioPlu = detToUp.PrecioPlu;
                    detalle.UnidadMedida = detToUp.UnidadMedida;

                    _unitOfWork.RepositorioDetalleFact.Update(detalle);
                    _unitOfWork.Save();
                    scope.Complete();

                    return "Detalle de factura modificado exitosamente!";
                }
                else
                    return "El detalle de factura especificado no encuentra registrado, por favor vuelva a intentarlo.";
            }
        }
    }
}
