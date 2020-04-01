using BusinessEntities;
using BusinessServices.Interfaces_de_Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace WebApiPosIp.Controllers
{
    [RoutePrefix("ConversionesDeProductos")]
    public class ConversionProductoController : ApiController
    {
        private readonly IConversionesProductos _conversionServices;

        public ConversionProductoController(IConversionesProductos conversionServices)
        {
            _conversionServices = conversionServices;
        }

        [EnableQuery]
        [Route("TodasLasConversiones")]
        public HttpResponseMessage TodasLasConversiones()
        {
            var conversiones = _conversionServices.TodasLasConversiones();
            if (conversiones != null)
            {
                var conversionEntity = conversiones as List<ConversionesProductosEnt> ?? conversiones.ToList();
                if (conversionEntity.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, conversionEntity);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron conversiones de productos registradas.");
        }

        [EnableQuery]
        [Route("ConversionPorId")]
        public HttpResponseMessage ConversionPorId(int idConversion)
        {
            var conversion = _conversionServices.ConversionPorId(idConversion);
            if (conversion != null)
                return Request.CreateResponse(HttpStatusCode.OK, conversion);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "La conversion solicitada no se encuentra registrada, por favor verifique e intente nuevamente.");
        }

        [EnableQuery]
        [Route("NuevaConversion")]
        public string NuevaConversion([FromBody] ConversionesProductosEnt nuevaConversion)
        {
            var result = _conversionServices.CrearConversion(nuevaConversion);
            return result;
        }

        [EnableQuery]
        [Route("ModificarConversion")]
        public string ModificarConversion([FromBody] int idConvsersion, [FromBody] ConversionesProductosEnt conversionToUp)
        {
            if (idConvsersion > 0)
                return _conversionServices.ModificarConversion(idConvsersion, conversionToUp);
            else
                return "La conversion que intenta modificar es invalida, por favor verfique e intente nuevamente.";
        }
    }
}
