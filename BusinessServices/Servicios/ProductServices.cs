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
    public class ProductServices : IProductServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ProductServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Servicio que retorna todos los productos registrados en la bd.
        public IEnumerable<BusinessEntities.ProductEnt> GetAllProducts()
        {
            var productos = _unitOfWork.RepositorioProducto.GetAll().ToList();
            if (productos.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Productos, BusinessEntities.ProductEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloProducto = mapper.Map<List<Productos>, List<BusinessEntities.ProductEnt>>(productos);
                return modeloProducto;
            }
            return null;
        }

        //Retorna un producto filtrado por el CodigoSAP
        public BusinessEntities.ProductEnt GetProductById(long idProducto)
        {
            var producto = _unitOfWork.RepositorioProducto.GetByID(idProducto);
            if (producto != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Productos, BusinessEntities.ProductEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloProducto = mapper.Map<Productos, BusinessEntities.ProductEnt>(producto);
                return modeloProducto;
            }
            return null;
        }

        //Retorna una lista de productos registrados filtrados por Categoria
        public IEnumerable<BusinessEntities.ProductEnt> GetProductsByCat(short idCategoria)
        {
            Func<Productos, Boolean> param = x => { if (x.IdCategoria == idCategoria) return true; else return false; };

            var productos = _unitOfWork.RepositorioProducto.GetMany(param).ToList();
            if (productos.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Productos, BusinessEntities.ProductEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloProducto = mapper.Map<List<Productos>, List<BusinessEntities.ProductEnt>>(productos);
                return modeloProducto;
            }
            return null;
        }

        //Servicio que inserta un nuevo registro de producto en la bd
        public long CreateProduct(BusinessEntities.ProductEnt nuevoProducto)
        {
            using (var scope = new TransactionScope())
            {
                var producto = new Productos
                {
                    NombreCompleto = nuevoProducto.NombreCompleto,
                    UnidadMedida = nuevoProducto.UnidadMedida,
                    IdCategoria = nuevoProducto.IdCategoria,
                    Precio = nuevoProducto.Precio,
                    Tipo = nuevoProducto.Tipo,
                    CodigoSAP = nuevoProducto.CodigoSAP,
                    EsServicio = nuevoProducto.EsServicio
                };
                _unitOfWork.RepositorioProducto.Insert(producto);
                _unitOfWork.Save();
                scope.Complete();
                return producto.CodigoSAP;
            }
        }
    }
}
