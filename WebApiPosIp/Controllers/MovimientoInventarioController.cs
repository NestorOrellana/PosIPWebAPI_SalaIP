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
    /// <summary>
    /// Controlador de servicios para los movimientos de inventario
    /// </summary>
    public class MovimientoInventarioController : ApiController
    {
        private readonly IMovimientoInventario _movimientosServices;

        public MovimientoInventarioController(IMovimientoInventario movimientosServices)
        {
            _movimientosServices = movimientosServices;
        }

        #region Servicios para movimientos de inventario
        /// <summary>
        /// Servicio que registra un unico movimiento de inventario
        /// </summary>
        /// <param name="nuevoMovimiento"></param>
        /// <returns>Identificador unico del movimiento registrado</returns>
        [EnableQuery]
        [Route("NuevoMovimientoInventario")]
        [HttpPost]
        public long RegistrarMovimiento([FromBody]MovimientoInventarioEnt nuevoMovimiento)
        {
            return _movimientosServices.RegistrarMovimientoInventario(nuevoMovimiento);
        }

        /// <summary>
        /// Servicio que registra una coleccion de movimientos de inventario
        /// </summary>
        /// <param name="movimientosDelDia"></param>
        /// <returns>Cadena de texto con el resultado de la operacion</returns>
        [EnableQuery]
        [Route("RegistrarMovimientosDelDia")]
        [HttpPost]
        public ResponseObject RegistrarMovimientosDelDia([FromBody]List<MovimientoInventarioEnt> movimientosDelDia)
        {
            return _movimientosServices.RegistrarMovimientosDelDia(movimientosDelDia);
        }
        #endregion
    }
}
