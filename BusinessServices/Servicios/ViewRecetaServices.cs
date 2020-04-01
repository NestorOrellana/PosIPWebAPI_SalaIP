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
    public class ViewRecetaServices : IViewRecetaServices
    {
        private readonly UnitOfWork _unitOfWork;

        public ViewRecetaServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ViewRecetaEnt> RecetasPorSucursal(short idSucursal)
        {
            Func<VistaReceta, Boolean> param = x => { return x.IdSucursal == idSucursal ? true : false; };
            var listaReceta = _unitOfWork.RepositorioVistaReceta.GetMany(param).ToList();
            if (listaReceta.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VistaReceta, ViewRecetaEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloReceta = mapper.Map<List<VistaReceta>, List<ViewRecetaEnt>>(listaReceta);
                return modeloReceta;
            }
            return null;
        }

        public IEnumerable<ViewRecetaEnt> TodasLasRecetas()
        {
            var listaReceta = _unitOfWork.RepositorioVistaReceta.GetAll().ToList();
            if (listaReceta.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VistaReceta, ViewRecetaEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloReceta = mapper.Map<List<VistaReceta>, List<ViewRecetaEnt>>(listaReceta);
                return modeloReceta;
            }
            return null;
        }
    }
}
