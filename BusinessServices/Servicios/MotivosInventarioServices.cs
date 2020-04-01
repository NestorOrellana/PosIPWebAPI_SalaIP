using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataModel.UnitOfWork;
using DataModel;
using System.Transactions;

namespace BusinessServices
{
    public class MotivosInventarioServices : IMotivosInventarioServices
    {
        private readonly UnitOfWork _unitOfWork;
        /*
        MotivosInventarioEnt GetMotivoInventario(int idMotivo);
        string UpdateMotivo(int idMotivo, MotivosInventarioEnt pluToUpdate);
        IEnumerable<MotivosInventarioEnt> TodosLosMotivos();
        string CreateMotivo(MotivosInventarioEnt nuevoMotivo);*/

        public MotivosInventarioServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Retorna un listado con todos los motivos de movimientos registrados en la bd
        public IEnumerable<BusinessEntities.MotivosInventarioEnt> TodosLosMotivos()
        {
            var listMotivos = _unitOfWork.RepositorioMInventario.GetAll().ToList();
            if (listMotivos.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MotivosInventario, BusinessEntities.MotivosInventarioEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloMotivos = mapper.Map<List<MotivosInventario>, List<BusinessEntities.MotivosInventarioEnt>>(listMotivos);
                return modeloMotivos;
            }
            return null;
        }

        //Retorna un motivo de movimiento de inventario especifico 
        public BusinessEntities.MotivosInventarioEnt GetMotivoInventario(int idMotivo)
        {
            Func<MotivosInventario, Boolean> param = x => { if (x.IdMotivo == idMotivo) return true; else return false; };
            var motivo = _unitOfWork.RepositorioMInventario.Get(param);
            if (motivo != null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MotivosInventario, BusinessEntities.MotivosInventarioEnt>();
                });

                IMapper mapper = config.CreateMapper();
                var modeloMotivo = mapper.Map<MotivosInventario, BusinessEntities.MotivosInventarioEnt>(motivo);
                return modeloMotivo;
            }
            return null;
        }

        //Servicio que inserta un nuevo motivo de movimiento de inventario
        public string CreateMotivo(BusinessEntities.MotivosInventarioEnt nuevoMotivo)
        {
            using (var scope = new TransactionScope())
            {
                var motivo = new MotivosInventario
                {
                    Descripcion = nuevoMotivo.Descripcion,
                    Estado = nuevoMotivo.Estado
                };
                _unitOfWork.RepositorioMInventario.Insert(motivo);
                _unitOfWork.Save();
                scope.Complete();
                return "Motivo registrado exitosamente!";
            }
        }

        //Metodo que modifica un motivo en especifico
        public string UpdateMotivo(int idMotivo, BusinessEntities.MotivosInventarioEnt motivoToUpdate)
        {
            using (var scope = new TransactionScope())
            {
                Func<MotivosInventario, Boolean> param = x => { if (x.IdMotivo == idMotivo) return true; else return false; };

                var motivo = _unitOfWork.RepositorioMInventario.Get(param);
                if (motivo != null)
                {
                    motivo.Descripcion = motivoToUpdate.Descripcion;
                    motivo.Estado = motivo.Estado;

                    _unitOfWork.RepositorioMInventario.Update(motivo);
                    _unitOfWork.Save();
                    scope.Complete();

                    return "Motivo modificado exitosamente!";
                }
                else
                    return "El Motivo indicado no se encuentra registrado, por favor vuelva a intentarlo.";
            }
        }
    }
}
