using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using BusinessEntities;
using BusinessServices;

namespace WebApiPosIp.Controllers
{
    public class SPPedidosController : ApiController
    {
        private readonly ISPGetPedidosServices _serviciosPedidos;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de Producto
        /// </summary>
        public SPPedidosController(ISPGetPedidosServices servicioPedido)
        {
            _serviciosPedidos = servicioPedido;
        }

        #endregion

        //-----Controlador que muestra todos los productos registrados en la bd-----//
        [EnableQuery]
        [Route("PedidoDelDia")]//ruta especificada para el webapi 
        public HttpResponseMessage Get(long codigoUsuario)
        {
            var pedido = _serviciosPedidos.GetPedido(codigoUsuario);
            if (pedido != null)
            {
                var entProducto =  pedido.ToList();
                if (entProducto.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, entProducto.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No hay pedidos programados para hoy.");
        }
    }
}
