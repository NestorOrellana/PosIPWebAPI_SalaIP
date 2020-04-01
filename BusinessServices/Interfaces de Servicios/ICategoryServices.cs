using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    //interfaz para definir la estructura de los servicios para las categorias
    public interface ICategoryServices
    {
        IEnumerable<CategoriaEnt> GetAllCategories();
        CategoriaEnt GetCategoryById(int id_categoria);
        int CreateCategory(CategoriaEnt nuevaCategoria);
    }
}
