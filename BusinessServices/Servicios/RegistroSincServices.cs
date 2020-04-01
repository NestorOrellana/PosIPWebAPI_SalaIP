using BusinessEntities;
using BusinessServices.Interfaces_de_Servicios;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessServices.Servicios
{
    public class RegistroSincServices : IRegistroSincServices
    {
        private readonly UnitOfWork _unitOfWork;

        public RegistroSincServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string NuevoRegistro(RegistroSincEnt registro)
        {
            using (var scope = new TransactionScope())
            {
                var registroS = new RegistroSincronizacion
                {
                    IdRegistro = registro.IdRegistro,
                    FechaRegistro = registro.FechaRegistro,
                    IdSucursal = registro.IdSucursal,
                    Operacion = registro.Operacion
                };

                _unitOfWork.RepositorioRegistroSinc.Insert(registroS);
                _unitOfWork.Save();
                scope.Complete();
                return "Ok";
            }
        }
    }
}
