using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface IRecipeServices
    {
        //Servicios para los detalles de recetas(Tabla de Recetas)
        IEnumerable<RecetaEnt> GetRecipeDetail(long idReceta);
        string UpdateRecipeDetail(long idProducto, long idReceta, short idSucursal, RecetaEnt detailToUpdate);
        RecetaEnt GetRecipeDetail(long idProducto, long idReceta, short idSucursal);
        string CreateRecipeDetail(RecetaEnt newRecipeDetail);
        IEnumerable<RecetaEnt> GetAllRecipeDetails();
        IEnumerable<RecetaEnt> RecetasPorSucursal(short IdSucursal);
    }
}
