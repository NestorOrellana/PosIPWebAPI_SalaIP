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
    public class PluServices /*: IPluServices*/
    {
        //private readonly UnitOfWork _unitOfWork;
        ///*
        //PluEnt GetPluById(int plu);
        //string UpdatePlu(int idPlu, PluEnt pluToUpdate);
        //IEnumerable<PluEnt> GetAllPlu();
        //string CreatePlu(PluEnt nuevoPlu);*/

        //public PluServices(UnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        ////Retorna un listado con todos los Plus registrados en la bd
        //public IEnumerable<BusinessEntities.PluEnt> GetAllPlu()
        //{
        //    Func<Plu, Boolean> param = x => { if (x.IdEstado == 1) return true; else return false; };
        //    var listPlu = _unitOfWork.RepositorioPlu.GetMany(param).ToList();
        //    if (listPlu.Any())
        //    {
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<Plu, BusinessEntities.PluEnt>();
        //        });

        //        IMapper mapper = config.CreateMapper();
        //        var modeloPlu = mapper.Map<List<Plu>, List<BusinessEntities.PluEnt>>(listPlu);
        //        return modeloPlu;
        //    }
        //    return null;
        //}

        ////-- Retorna todos los PLU registrados para una Sucursal especifica --//
        //public IEnumerable<BusinessEntities.PluEnt> GetPluPorSucursal(int idSucursal)
        //{
        //    Func<Plu, Boolean> param = x => { return x.IdSucursal == idSucursal && x.IdEstado == 1 ? true : false; };
        //    var listPlu = _unitOfWork.RepositorioPlu.GetMany(param).ToList();
        //    if(listPlu.Any())
        //    {
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<Plu, BusinessEntities.PluEnt>();
        //        });

        //        IMapper mapper = config.CreateMapper();
        //        var modeloPlu = mapper.Map<List<Plu>, List<BusinessEntities.PluEnt>>(listPlu);
        //        return modeloPlu;
        //    }
        //    return null;
        //}

        ////Retorna un plu especifico 
        //public BusinessEntities.PluEnt GetPluById(int idPlu)
        //{
        //    Func<Plu, Boolean> param = x => { if (x.IdPLU == idPlu) return true; else return false; };
        //    var plu = _unitOfWork.RepositorioPlu.Get(param);
        //    if (plu != null)
        //    {
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<Plu, BusinessEntities.PluEnt>();
        //        });

        //        IMapper mapper = config.CreateMapper();
        //        var modeloPlu = mapper.Map<Plu, BusinessEntities.PluEnt>(plu);
        //        return modeloPlu;
        //    }
        //    return null;
        //}

        ////Servicio que inserta un nuevo registro de Plu
        //public string CreatePlu(BusinessEntities.PluEnt nuevoPlu)
        //{
        //    using (var scope = new TransactionScope())
        //    {
        //        var plu = new Plu
        //        {
        //            IdPLU = nuevoPlu.IdPLU,
        //            IdReceta = nuevoPlu.IdReceta,
        //            IdUnidadVenta = nuevoPlu.IdUnidadVenta,
        //            IdEstado = nuevoPlu.IdEstado,
        //            IdCategoria = nuevoPlu.IdCategoria,
        //            Descripcion = nuevoPlu.Descripcion,
        //            precio = nuevoPlu.precio
        //        };
        //        _unitOfWork.RepositorioPlu.Insert(plu);
        //        _unitOfWork.Save();
        //        scope.Complete();
        //        return "Detalle registrado exitosamente!";
        //    }
        //}

        ////Metodo que modifica un plu en especifico
        //public string UpdatePlu(int idPlu, BusinessEntities.PluEnt pluToUpdate)
        //{
        //    using (var scope = new TransactionScope())
        //    {
        //        Func<Plu, Boolean> param = x => { if (x.IdPLU == idPlu) return true; else return false; };

        //        var plu = _unitOfWork.RepositorioPlu.Get(param);
        //        if (plu != null)
        //        {
        //            plu.IdPLU = pluToUpdate.IdPLU;
        //            plu.IdReceta = pluToUpdate.IdReceta;
        //            plu.IdUnidadVenta = pluToUpdate.IdUnidadVenta;
        //            plu.IdEstado = pluToUpdate.IdEstado;
        //            plu.Descripcion = pluToUpdate.Descripcion;
        //            plu.precio = pluToUpdate.precio;
        //            plu.IdCategoria = pluToUpdate.IdCategoria;

        //            _unitOfWork.RepositorioPlu.Update(plu);
        //            _unitOfWork.Save();
        //            scope.Complete();

        //            return "Plu modificado exitosamente!";
        //        }
        //        else
        //            return "El plu indicado se encuentra registrado, por favor vuelva a intentarlo.";
        //    }
        //}
    }
}
