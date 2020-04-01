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
    public class RegistroSincController : ApiController
    {
        private readonly IRegistroSincServices _registroSincServices;

        public RegistroSincController(IRegistroSincServices registroSincServices)
        {
            _registroSincServices = registroSincServices;
        }

        [EnableQuery]
        [Route("NuevoRegistroSinc")]
        public string nuevoRegistroSinc([FromBody]RegistroSincEnt nuevoRegistro)
        {
            return _registroSincServices.NuevoRegistro(nuevoRegistro);
        }
    }
}
