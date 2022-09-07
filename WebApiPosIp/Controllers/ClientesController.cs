using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;
using System.Web.Http.OData;
using System.Threading.Tasks;

namespace WebApiPosIp.Controllers
{
    [RoutePrefix("Clientes")]
    public class ClientesController : ApiController
    {
        private readonly IClientesServices _clientesServices;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de clientes
        /// </summary>
        public ClientesController(IClientesServices clientesServices)
        {
            _clientesServices = clientesServices;
        }
        #endregion

        //-----Controlador que muestra todas los clientes registrados en la bd-----//
        [EnableQuery]
        [HttpGet]
        [Route("TodosLosClientes")]
        public HttpResponseMessage TodosLosClientes()
        {
            var clientes =  _clientesServices.GetAllClientes();
            if (clientes != null)
            {
                var clienteEntity = clientes as List<ClientesEnt> ?? clientes.ToList();
                if (clienteEntity.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, clienteEntity);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron clientes registrados.");
        }

        [EnableQuery]
        [HttpGet]
        [Route("ClientePorNit")]
        public HttpResponseMessage ClientePorNit(string nit)
        {
            var cliente = _clientesServices.GetClientePorNit(nit);
            if(cliente != null)
            {
                var clienteEntity = cliente as ClientesEnt ?? cliente;
                if (clienteEntity != null)
                    return Request.CreateResponse(HttpStatusCode.OK, clienteEntity);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontro ningun cliente con el nit indicado");
        }
    }
}
