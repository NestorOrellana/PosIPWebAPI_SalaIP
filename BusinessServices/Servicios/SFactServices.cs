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
    public class SFactServices : ISFactServices
    {
        private readonly UnitOfWork _unitOfWork;

        public SFactServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Metodos Eliminados
        //Retorna el registro completo del numero de serie de una factura filtrado por su Id
        //public BusinessEntities.ViewFacturaSerieEnt GetFactS(int IdSerie)
        //{
        //    var SerieFactura = _unitOfWork.RepositorioFactS.GetByID(IdSerie);
        //    if (SerieFactura != null)
        //    {
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<VistaSeriesFacturas, BusinessEntities.ViewFacturaSerieEnt>();
        //        });

        //        IMapper mapper = config.CreateMapper();
        //        var modeloFactura = mapper.Map<VistaSeriesFacturas, BusinessEntities.ViewFacturaSerieEnt>(SerieFactura);
        //        return modeloFactura;
        //    }
        //    return null;
        //}
        #endregion

        /// <summary>
        /// Retorna el Numero de serie y Correlativo activo(en uso) de una sucursal en especifico
        /// </summary>
        /// <param name="IdSucursal">Id de la sucursal que consulta su numero de serie y correlativo activo.</param>
        /// <returns></returns>
        public BusinessEntities.ViewFacturaSerieEnt GetFactSBySucursal(int IdSucursal)
        {
            Func<Series, Boolean> param = x => { if ((x.idSucursal == IdSucursal) && (x.idEstado == 1)) return true; else return false; };

            var FactSerie = _unitOfWork.RepositorioFactS.Get(param);
            if (FactSerie != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Series, BusinessEntities.ViewFacturaSerieEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloFactura = mapper.Map<Series, BusinessEntities.ViewFacturaSerieEnt>(FactSerie);
                return modeloFactura;
            }
            return null;
        }

        /// <summary>
        /// Retorna una lista de Numeros de Serie y Correlativos que posee una sucursal en especifico.
        /// </summary>
        /// <param name="idSucursal">Id de la sucursal que consulta los sus numeros de serie y correlativos disponibles.</param>
        /// <returns></returns>
        public IEnumerable<BusinessEntities.ViewFacturaSerieEnt> GetSeriesBySucursal(int idSucursal)
        {
            Func<Series, Boolean> param = x => { if (x.idSucursal == idSucursal) return true; else return false; };

            var seriesFacturas = _unitOfWork.RepositorioFactS.GetMany(param).ToList();
            if (seriesFacturas.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Series, BusinessEntities.ViewFacturaSerieEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloSFacturas = mapper.Map<List<Series>, List<BusinessEntities.ViewFacturaSerieEnt>>(seriesFacturas);
                return modeloSFacturas;
            }
            return null;
        }

        /// <summary>
        /// Metod que modifica un detalle de receta especifico
        /// </summary>
        /// <param name="IdSerie">Id de la serie de la factura a la que se le modificara el correlativo</param>
        /// <param name="IdSucursal">Id de la sucursal a la cual pertenece la factura a modificar</param>
        /// <returns></returns>
        public string UpdateFactS(short IdSerie, short IdSucursal)
        {
            using (var scope = new TransactionScope())
            {
                string msgReturn = "";
                Func<Series, Boolean> param = x => { if ((x.idSerie == IdSerie) && (x.idSucursal == IdSucursal)) return true; else return false; };

                var NoSerie = _unitOfWork.RepositorioFactS.Get(param);
                if (NoSerie != null)
                {
                    if((NoSerie.correlativo + 1) > NoSerie.numeroAl)
                    {
                        Func<Series, Boolean> paramActive = x => { if ((x.idSucursal == IdSucursal) && (x.idEstado == 2)) return true; else return false; };
                        var NewSerie = _unitOfWork.RepositorioFactS.Get(paramActive);
                        if(NewSerie == null)
                            msgReturn = "La sucursal ya no posee facturas para poder facturar.";
                        else
                        {
                            NewSerie.idEstado = 1;
                            NewSerie.estado = "Activa";
                            _unitOfWork.RepositorioFactS.Update(NewSerie);
                            _unitOfWork.Save();
                        }

                        NoSerie.idEstado = 2;
                        NoSerie.estado = "Inactiva";
                        msgReturn = "Correlativo actualizado exitosamente!";
                    }
                    else
                    {
                        NoSerie.correlativo += 1;
                        msgReturn = "No Correlativo actualizado exitosamente!";
                    }

                    _unitOfWork.RepositorioFactS.Update(NoSerie);
                    _unitOfWork.Save();
                    scope.Complete();

                    return msgReturn;
                }
                else
                    return "El Numero de Serie indicado no se encontro registrado por favor vuelva a intentarlo mas tarde.";
            }
        }
    }
}
