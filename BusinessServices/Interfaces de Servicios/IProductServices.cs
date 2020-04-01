using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    public interface IProductServices
    {
        IEnumerable<ProductEnt> GetAllProducts();
        ProductEnt GetProductById(long idProducto);
        IEnumerable<ProductEnt> GetProductsByCat(short idCategoria);
        long CreateProduct(ProductEnt newProduct);
    }
}
