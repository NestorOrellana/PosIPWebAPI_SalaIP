using AutoMapper;
using BusinessEntities;
using BusinessServices.Interfaces_de_Servicios;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class ClientesServices : IClientesServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public ClientesServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ClientesEnt> GetAllClientes()
        {

            var clientes = _unitOfWork.RepositorioClientes.GetAll().ToList();
            if (clientes.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Clientes, ClientesEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloCliente = mapper.Map<List<Clientes>, List<ClientesEnt>>(clientes);
                return modeloCliente;
            }
            return null;
        }

        public ClientesEnt GetClientePorNit(string nit)
        {
            Func<Clientes, Boolean> param = x => { if (x.IdFiscal1 == nit) return true; else return false; };

            var cliente = _unitOfWork.RepositorioClientes.GetFirst(param);
            if (cliente != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Clientes, ClientesEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloCliente = mapper.Map<Clientes, ClientesEnt>(cliente);
                return modeloCliente;
            }
            return null;
        }
    }
}
