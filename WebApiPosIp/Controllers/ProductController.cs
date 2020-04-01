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
    [RoutePrefix("Product")]
    public class ProductController : ApiController
    {
        private readonly IProductServices _servicioProducto;

        #region Public Constructor

        /// <summary>
        /// Constructor publico que inicializa una instancia de los servicios de Producto
        /// </summary>
        public ProductController(IProductServices servicioproducto)
        {
            _servicioProducto = servicioproducto;
        }

        #endregion

        //-----Controlador que muestra todos los productos registrados en la bd-----//
        [EnableQuery]
        [Route("allProducts")]//ruta especificada para el webapi
        public HttpResponseMessage Get()
        {
            var productos = _servicioProducto.GetAllProducts();
            if (productos != null)
            {
                var entProducto = productos as List<ProductEnt> ?? productos.ToList();
                if (entProducto.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, entProducto.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron productos registrados.");
        }

        //------Controlador que retorna un producto basado en su id-------//
        [EnableQuery]
        [Route("ProductById")]//ruta especificada para el webapi
        public HttpResponseMessage Get(long id)
        {
            var producto = _servicioProducto.GetProductById(id);
            if (producto != null)
                return Request.CreateResponse(HttpStatusCode.OK, producto);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "El producto indicado no se encuentra registrado.");
        }

        //----------Controlador que inserta un nuevo registro de Producto en la bd-----------------------//
        [EnableQuery]
        [Route("NewProduct")]//Ruta especificada para el webapi
        public long Post([FromBody] ProductEnt nuevoProducto)
        {
            return _servicioProducto.CreateProduct(nuevoProducto);
        }

        //----------Controlador que retorna todos los productos registrados filtrados por categoria-------------------//
        [EnableQuery]
        [Route("ProductByCat")]
        public HttpResponseMessage GetByCategory(short idCategoria)
        {
            var productos = _servicioProducto.GetProductsByCat(idCategoria);
            if (productos != null)
            {
                var entProducto = productos as List<ProductEnt> ?? productos.ToList();
                if (entProducto.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, entProducto.AsQueryable());
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No se encontraron productos registrados de la categoria indicada.");
        }
    }
}
