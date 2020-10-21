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
    [RoutePrefix("Users")]//prefijo comun en todos los controladores
    public class UserController : ApiController
    { 
        private readonly IUserServices _userServices;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de usuario
        /// </summary>
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        #endregion

        //-----Controlador que muestra todos los usuarios registrados en la bd-----//
        /// <summary>
        /// Retorna todos los usuarios
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        [Route("allusers")]//ruta especificada para el webapi
        public HttpResponseMessage Get()
        {
            var users = _userServices.GetAllUsers();
            if (users != null)
            {
                var userEntity = users as List<UsuarioEnt> ?? users.ToList();
                if (userEntity.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, userEntity);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron usuarios registrados.");
        }

        //-------Controlador que verifica si el id del usaurio y el PIN de este existen y coinciden
        [EnableQuery]
        [HttpPost]
        [Route("verifyUser")]//ruta especificada para el webapi
        public HttpResponseMessage GetUserWhere(string user, short PIN)
        {
            var usuario = _userServices.GetUserWhere(user, PIN);
            if (usuario != null)
                return Request.CreateResponse(HttpStatusCode.OK, usuario);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El ID de usuario o el PIN son incorrectos, por favor vuelva a intentarlo.");
        }

        //------Controlador que retorna un usuarios basado en su id-------//
        [EnableQuery]
        [Route("getById")]//ruta especificada para el webapi
        public HttpResponseMessage Get(short id)
        {
            var usuario = _userServices.GetUserById(id);
            if (usuario != null)
                return Request.CreateResponse(HttpStatusCode.OK, usuario);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El usuario indicado no fue encontrado.");
        }

        [EnableQuery]
        [Route("GetUsersBySucursal")]
        public HttpResponseMessage GetUsersById(short idSucursal)
        {
            var usuarios = _userServices.GetUsersBySucursal(idSucursal);
            if (usuarios != null)
                return Request.CreateResponse(HttpStatusCode.OK, usuarios);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encuentran usuarios registrados para la sucursal indicada");
        }

        //------Controlador que inserta un registro de usuario en la bd-----//
        [EnableQuery]
        [Route("create")]//ruta especificada para el webapis
        public long Post([FromBody] UsuarioEnt nuevoUsuario)
        {
            return _userServices.CreateUser(nuevoUsuario);
        }

        //------Controlador que valida que la contraseña ingresada sea de un administrador-------------//
        [EnableQuery]
        [Route("ValidateAdmin")]
        public bool ValidateAdmin([FromBody] string userPass)
        {
            return _userServices.ValidateIfAdmin(userPass);
        }

        [EnableQuery]
        [Route("ValidarUsuarioAdministrador")]
        [HttpPost]
        public bool ValidateAdminUser(string usuario, string password)
        {
            return _userServices.ValidateAdminUser(usuario, password);
        }
    } 
}