using AutoMapper;
using BusinessEntities;
using BusinessServices.Interfaces_de_Servicios;
using DataModel;
using DataModel.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices.Servicios
{
    public class ViewPluServices : IViewPluServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ViewPluServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ViewPluEnt> PluPorSucursal(short idSucursal)
        {
            Func<VistaPLU, Boolean> param = x => { return x.IdSucursal == idSucursal ? true : false; };
            var listPlu = _unitOfWork.RepositorioVistaPlu.GetMany(param).ToList();
            if (listPlu.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VistaPLU, ViewPluEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloPlu = mapper.Map<List<VistaPLU>, List<ViewPluEnt>>(listPlu);
                return modeloPlu;
            }
            return null;
        }

        public IEnumerable<ViewPluEnt> TodosLosPlu()
        {
            Func<VistaPLU, Boolean> param = x => { return x.IdEstado; };
            var listPlu = _unitOfWork.RepositorioVistaPlu.GetMany(param).ToList();
            if (listPlu.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VistaPLU, ViewPluEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloPlu = mapper.Map<List<VistaPLU>, List<ViewPluEnt>>(listPlu);
                return modeloPlu;
            }
            return null;
        }
    }
}
