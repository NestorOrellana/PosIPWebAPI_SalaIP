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
    public class CategoryServices : ICategoryServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public CategoryServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Servicio que inserta una nueva categoria en la base de datos
        public int CreateCategory(BusinessEntities.CategoriaEnt nuevaCategoria)
        {
            using (var scope = new TransactionScope())
            {
                var categoria = new Categorias
                {
                    IdCategoria = nuevaCategoria.IdCategoria,
                    Descripcion = nuevaCategoria.Descripcion
                };
                _unitOfWork.RepositorioCategoria.Insert(categoria);
                _unitOfWork.Save();
                scope.Complete();
                return categoria.IdCategoria;
            }
        }

        //Servicio que retorna todos los usuarios registrados en la bd.
        public IEnumerable<BusinessEntities.CategoriaEnt> GetAllCategories()
        {
            var categorias = _unitOfWork.RepositorioCategoria.GetAll().ToList();
            if (categorias.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Categorias, BusinessEntities.CategoriaEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloCategoria = mapper.Map<List<Categorias>, List<BusinessEntities.CategoriaEnt>>(categorias);
                return modeloCategoria;
            }
            return null;
        }

        //Retorna un usuario filtrado por su Id
        public BusinessEntities.CategoriaEnt GetCategoryById(int idCategoria)
        {
            var categoria = _unitOfWork.RepositorioCategoria.GetByID(idCategoria);
            if (categoria != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Categorias, BusinessEntities.CategoriaEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloCategoria = mapper.Map<Categorias, BusinessEntities.CategoriaEnt>(categoria);
                return modeloCategoria;
            }
            return null;
        }
    }
}
