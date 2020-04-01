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
    public class ServiciosConversiones : IConversionesProductos
    {
        private readonly UnitOfWork _unitOfWork;

        public ServiciosConversiones(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Servicio que retorna una conversion en especifico registrada.
        /// </summary>
        /// <param name="idConversion">Id de la conversion que se solicita</param>
        /// <returns>Conversion previamente registrada</returns>
        public ConversionesProductosEnt ConversionPorId(int idConversion)
        {
            var conversion = _unitOfWork.RepositorioConversiones.GetByID(idConversion);
            if(conversion != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ConversionesProductos, ConversionesProductosEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloConversion = mapper.Map<ConversionesProductos, ConversionesProductosEnt>(conversion);
                return modeloConversion;
            }

            return null;
        }

        /// <summary>
        /// Servicio que crea y registra una nueva conversion de productos.
        /// </summary>
        /// <param name="nuevaConversion"></param>
        /// <returns>Mensaje de fin de operacion</returns>
        public string CrearConversion(ConversionesProductosEnt nuevaConversion)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    var conversion = new ConversionesProductos
                    {
                        IdConversion = nuevaConversion.IdConversion,
                        IdProductoSAP = nuevaConversion.IdProductoSAP,
                        Cantidad = nuevaConversion.Cantidad,
                        IdProductoDestino = nuevaConversion.IdProductoDestino
                    };

                    _unitOfWork.RepositorioConversiones.Insert(conversion);
                    _unitOfWork.Save();
                    scope.Complete();
                    return "Conversion registrada exitosamente!.";
                }
                catch (Exception e)
                {
                    return $"Ha ocurrido un problema al intentar registrar la conversion. [{e.Message}]";
                }
            }
        }

        /// <summary>
        /// Servicio que modifica un registro de Conversion de producto actualmente registrado.
        /// </summary>
        /// <param name="idConversion">id de la conversion a modificar</param>
        /// <param name="conversion">datos nuevos de la conversion a modificar</param>
        /// <returns></returns>
        public string ModificarConversion(int idConversion, ConversionesProductosEnt conversion)
        {
            using (var scope = new TransactionScope())
            {
                Func<ConversionesProductos, bool> param = x => { return x.IdConversion == idConversion ? true : false; };

                var registroConversion = _unitOfWork.RepositorioConversiones.Get(param);
                if (registroConversion != null)
                {
                    try
                    {
                        registroConversion.IdProductoSAP = conversion.IdProductoSAP;
                        registroConversion.Cantidad = conversion.Cantidad;
                        registroConversion.IdProductoDestino = conversion.IdProductoDestino;

                        _unitOfWork.RepositorioConversiones.Update(registroConversion);
                        _unitOfWork.Save();
                        scope.Complete();

                        return "Conversion modificada exitosamente!.";
                    }
                    catch (Exception e)
                    {
                        return $"Ha ocurrido un problema al intentar modificar el registro de conversion solicitada. [{e.Message}]";
                    }
                }
                else
                    return "La conversion que desea modificar no se encuentra registrada por favor verifique y vuelva a intentarlo.";
            }
        }

        /// <summary>
        /// Servicio que retorna todas las conversiones de productos registradas
        /// </summary>
        /// <returns>Lista de conversiones registradas</returns>
        public IEnumerable<ConversionesProductosEnt> TodasLasConversiones()
        {
            var conversiones = _unitOfWork.RepositorioConversiones.GetAll().ToList();
            if(conversiones.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ConversionesProductos, ConversionesProductosEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloConversion = mapper.Map<List<ConversionesProductos>, List<ConversionesProductosEnt>>(conversiones);
                return modeloConversion;
            }

            return null;
        }
    }
}
