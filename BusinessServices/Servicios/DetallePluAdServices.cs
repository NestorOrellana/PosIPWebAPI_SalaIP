using AutoMapper;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BusinessServices
{
    public class DetallePluAdServices : IDetallePluAdServices
    {
        private readonly UnitOfWork _unitOfWork;

        public DetallePluAdServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Retorna un listado con todos los detalles de un producto de una factura en especifico
        public IEnumerable<BusinessEntities.DetallePluAdquiridoEnt> GetDetallesByIdFact(int idDetalleFactura)
        {
            Func<DetallePluAdquirido, Boolean> param = x => { if (x.IdDetalleFactura == idDetalleFactura) return true; else return false; };
            var listaDetalles = _unitOfWork.RepositorioDetallePluAd.GetMany(param).ToList();
            if (listaDetalles.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DetallePluAdquirido, BusinessEntities.DetallePluAdquiridoEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloDetalle = mapper.Map<List<DetallePluAdquirido>, List<BusinessEntities.DetallePluAdquiridoEnt>>(listaDetalles);
                return modeloDetalle;
            }
            return null;
        }

        //Retorna un detalle de producto en especifico de una factura
        public BusinessEntities.DetallePluAdquiridoEnt GetPluDetalle(int IdDetalle)
        {
            Func<DetallePluAdquirido, Boolean> param = x => { if (x.IdDetalle == IdDetalle) return true; else return false; };
            var detalle = _unitOfWork.RepositorioDetallePluAd.Get(param);
            if (detalle != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DetallePluAdquirido, BusinessEntities.DetallePluAdquiridoEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloDetalle = mapper.Map<DetallePluAdquirido, BusinessEntities.DetallePluAdquiridoEnt>(detalle);
                return modeloDetalle;
            }
            return null;
        }

        //Servicio que registra un nuevo detalle de factura en la bd
        public string CreateDetalle(BusinessEntities.DetallePluAdquiridoEnt nuevoDetalle)
        {
            using (var scope = new TransactionScope())
            {
                var detalle = new DetallePluAdquirido
                {
                    Cantidad = nuevoDetalle.Cantidad,
                    IdDetalleFactura = nuevoDetalle.IdDetalleFactura,
                    IdProducto = nuevoDetalle.IdProducto,
                    PrecioUnitario = nuevoDetalle.PrecioUnitario
                };
                _unitOfWork.RepositorioDetallePluAd.Insert(detalle);
                _unitOfWork.Save();
                scope.Complete();
                return "Detalle de producto registrado exitosamente!";
            }
        }

        //Metodo que modifica un detalle de plu en especifico de una factura
        public string UpdatePluDet(int IdDetalle, BusinessEntities.DetallePluAdquiridoEnt detToUp)
        {
            using (var scope = new TransactionScope())
            {
                Func<DetallePluAdquirido, Boolean> param = x => { if (x.IdDetalle == IdDetalle) return true; else return false; };

                var detalle = _unitOfWork.RepositorioDetallePluAd.Get(param);
                if (detalle != null)
                {
                    detalle.Cantidad = detToUp.Cantidad;
                    detalle.IdDetalleFactura = detToUp.IdDetalleFactura;
                    detalle.IdProducto = detToUp.IdProducto;
                    detalle.PrecioUnitario = detToUp.PrecioUnitario;

                    _unitOfWork.RepositorioDetallePluAd.Update(detalle);
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
