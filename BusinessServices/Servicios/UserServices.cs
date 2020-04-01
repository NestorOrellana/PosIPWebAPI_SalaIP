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
    //Clase que implementa la interfaz de los servicios de usuario
    public class UserServices : IUserServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public UserServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Servicio que retorna todos los usuarios registrados en la bd.
        public IEnumerable<BusinessEntities.UsuarioEnt> GetAllUsers()
        {
            var usuarios = _unitOfWork.RepositorioUsuario.GetAll().ToList();
            if (usuarios.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Usuarios, BusinessEntities.UsuarioEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloUsuario = mapper.Map<List<Usuarios>, List<BusinessEntities.UsuarioEnt>>(usuarios);
                return modeloUsuario;
            }
            return null;
        }

        //Servicio que inserta un nuevo registro Usuario en la bd
        public long CreateUser(BusinessEntities.UsuarioEnt nuevoUsuario)
        {
            using (var scope = new TransactionScope())
            {
                var usuario = new Usuarios
                {
                    PIN = nuevoUsuario.PIN,
                    IdSucursal = nuevoUsuario.IdSucursal,
                    IdTipoUsuario = nuevoUsuario.IdTipoUsuario,
                    Estado = nuevoUsuario.Estado,
                    Nombre = nuevoUsuario.Nombre,
                    IdUsuario = nuevoUsuario.IdUsuario,
                    Usuario = nuevoUsuario.Usuario
                };
                _unitOfWork.RepositorioUsuario.Insert(usuario);
                _unitOfWork.Save();
                scope.Complete();
                return usuario.IdUsuario;
            }
        }

        //Retorna un usuario filtrado por su Id
        public BusinessEntities.UsuarioEnt GetUserById(long idUsuario)
        {
            var usuario = _unitOfWork.RepositorioUsuario.GetByID(idUsuario);
            if (usuario != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Usuarios, BusinessEntities.UsuarioEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloUsuario = mapper.Map<Usuarios, BusinessEntities.UsuarioEnt>(usuario);
                return modeloUsuario;
            }
            return null;
        }

        //Retorna un usuario filtrado por su Id
        public BusinessEntities.UsuarioEnt GetUserWhere(string user, short PIN)
        {
            int i = 0;
            //Get(Func<TEntity, Boolean> where; 
            Func<Usuarios, Boolean> param = x => { if (user != null && PIN.ToString().Count() > 0) { if (x.Usuario.Equals(user) && x.PIN == PIN) return true; else return false; } else return false; };
            var usuario = _unitOfWork.RepositorioUsuario.Get(param);        
            if (usuario != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Usuarios, BusinessEntities.UsuarioEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloUsuario = mapper.Map<Usuarios, BusinessEntities.UsuarioEnt>(usuario);
                return modeloUsuario;
            }
            return null;
        }

        public IEnumerable<BusinessEntities.UsuarioEnt> GetUsersBySucursal(short idSucursal)
        {
            Func<Usuarios, bool> param = x => { if (x.IdSucursal == idSucursal || x.IdTipoUsuario == 20) return true; else return false; };

            var usuarios = _unitOfWork.RepositorioUsuario.GetMany(param).ToList();
            if(usuarios.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Usuarios, BusinessEntities.UsuarioEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloUsuario = mapper.Map<List<Usuarios>, List<BusinessEntities.UsuarioEnt>>(usuarios);
                return modeloUsuario;
            }
            return null;
        }

        public bool ValidateIfAdmin(string pass)
        {
            Func<Usuarios, bool> param = x => {
                if (!string.IsNullOrEmpty(pass) && pass.Equals(x.PIN.ToString()) && x.Estado)
                    return true;
                else
                    return false;
            };

            var usuario = _unitOfWork.RepositorioUsuario.Get(param);

            return usuario != null ? true : false;
        }
    }
}
