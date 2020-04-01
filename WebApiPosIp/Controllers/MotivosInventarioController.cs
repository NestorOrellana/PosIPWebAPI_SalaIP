using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;
using System.Web.Http.OData;

namespace WebApiPosIp.Controllers
{
    public class MotivosInventarioController : ApiController
    {
        private readonly IMotivosInventarioServices _mminventario;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de los motivos de movimientos de inventario
        /// </summary>
        public MotivosInventarioController(IMotivosInventarioServices mminventario)
        {
            _mminventario = mminventario;
        }

        #endregion

        //-----Controlador que muestra los registros de plu almacenados en la bd-----//
        [EnableQuery]
        [HttpGet]
        [Route("TodosLosMotivos")]//ruta especificada para el webapi
        public HttpResponseMessage TodosLosMotivos()
        {
            var motivos = _mminventario.TodosLosMotivos();
            if (motivos != null)
            {
                var listaMotivos = motivos as List<MotivosInventarioEnt> ?? motivos.ToList();
                if (listaMotivos.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, listaMotivos.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron motivos registrados.");
        }

        //------Controlador que retorna un motivo de movimiento de inventario en especifico registrado en la bd-------//
        [EnableQuery]
        [Route("getMotivo")]//ruta especifica para el web api
        public HttpResponseMessage Get(int idMotivo)
        {
            var motivo = _mminventario.GetMotivoInventario(idMotivo);
            if (motivo != null)
                return Request.CreateResponse(HttpStatusCode.OK, motivo);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El plu indicado no existe registrado, por favor vuela a intentarlo.");
        }

        //----------Controlador que inserta un nuevo motivo de movimiento de inventario en la bd-----------------------//
        [EnableQuery]
        [Route("newMotivo")]//Ruta especificada para el webapi
        public string Post([FromBody] MotivosInventarioEnt nuevoMotivo)
        {
            return _mminventario.CreateMotivo(nuevoMotivo);
        }

        //----------Controlador que actualiza un plu registrado en la bd-----------------//
        [EnableQuery]
        [Route("updateMotivo")]//Ruta especifica para el webapi
        public string Put(int idMotivo, [FromBody]MotivosInventarioEnt upMotivo)
        {
            if (idMotivo > 0)
            {
                return _mminventario.UpdateMotivo(idMotivo, upMotivo);
            }
            return "Motivo modificado exitosamente.";
        }
    }
}
