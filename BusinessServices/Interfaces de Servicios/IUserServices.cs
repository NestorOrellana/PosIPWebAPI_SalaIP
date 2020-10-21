using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices
{
    //Interfaz para los servicios de Usuario
    public interface IUserServices
    {
        IEnumerable<UsuarioEnt> GetAllUsers();
        UsuarioEnt GetUserById(long userId);
        long CreateUser(UsuarioEnt nuevoUsuario);
        UsuarioEnt GetUserWhere(string Usuario, short PIN);
        bool ValidateIfAdmin(string pass);
        bool ValidateAdminUser(string usuario, string password);
        IEnumerable<UsuarioEnt> GetUsersBySucursal(short idSucursal);
        //bool UpdateProduct(int productId, ProductEntity productEntity);
        //bool DeleteProduct(int productId);
    }
}