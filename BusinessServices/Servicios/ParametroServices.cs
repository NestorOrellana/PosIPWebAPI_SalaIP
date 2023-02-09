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

namespace BusinessServices.Servicios
{
    public class ParametroServices : IParametroServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ParametroServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ParametrosEnt> GetParametros()
        {
            var parametros = _unitOfWork.RepositorioParametros.GetAll().ToList();
            if (parametros.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Parametros, ParametrosEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var listaParametros = mapper.Map<List<Parametros>, List<ParametrosEnt>>(parametros);
                return listaParametros;
            }
            return null;
        }
    }
}
