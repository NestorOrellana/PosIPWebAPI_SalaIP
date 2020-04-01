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
    public class RecipeServices /*: IRecipeServices*/
    {
        ///*Servicios de interfaz de recetas a implementar
        // * IEnumerable<RecetaEnt> GetRecipeDetail();
        //RecetaEnt GetRecipeDetail(int idProducto, int idDetail);
        //string CreateRecipeDetail(RecetaEnt newRecipeDetail);*/
        //private readonly UnitOfWork _unitOfWork;

        //public RecipeServices(UnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        ////Retorna el detalle completo de la receta especificada
        //public IEnumerable<BusinessEntities.RecetaEnt> GetRecipeDetail(long idReceta)
        //{
        //    Func<Receta, Boolean> param = x => { if (x.IdReceta == idReceta) return true; else return false; };

        //    var detalleReceta = _unitOfWork.RepositorioReceta.GetMany(param).ToList();
        //    if (detalleReceta.Any())
        //    {
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<Receta, BusinessEntities.RecetaEnt>();
        //        });

        //        IMapper mapper = config.CreateMapper();
        //        var modeloDetalle = mapper.Map<List<Receta>, List<BusinessEntities.RecetaEnt>>(detalleReceta);
        //        return modeloDetalle;
        //    }
        //    return null;
        //}

        ////-- Servicio que retorna la lista de recetas registradas para una Sucursal especifica --//
        //public IEnumerable<BusinessEntities.RecetaEnt> RecetasPorSucursal(short idSucursal)
        //{
        //    Func<Receta, Boolean> param = x => { return x.IdSucursal == idSucursal ? true : false; };

        //    var detalleReceta = _unitOfWork.RepositorioReceta.GetMany(param).ToList();
        //    if(detalleReceta.Any())
        //    {
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<Receta, BusinessEntities.RecetaEnt>();
        //        });

        //        IMapper mapper = config.CreateMapper();
        //        var modeloDetalle = mapper.Map<List<Receta>, List<BusinessEntities.RecetaEnt>>(detalleReceta);
        //        return modeloDetalle;
        //    }
        //    return null;
        //}

        ////Retorna un detalle de la receta especifico 
        //public BusinessEntities.RecetaEnt GetRecipeDetail(long idProducto, long idReceta, short idSucursal)
        //{
        //    Func<Receta, Boolean> param = x => { if ((x.IdProducto == idProducto) && (x.IdReceta == idReceta) && (x.IdSucursal == idSucursal)) return true; else return false; };
        //    var detalleReceta = _unitOfWork.RepositorioReceta.Get(param);
        //    if (detalleReceta != null)
        //    {
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<Receta, BusinessEntities.RecetaEnt>();
        //        });

        //        IMapper mapper = config.CreateMapper();
        //        var modeloDetalle = mapper.Map<Receta, BusinessEntities.RecetaEnt>(detalleReceta);
        //        return modeloDetalle;
        //    }
        //    return null;
        //}

        ////Servicio que inserta un nuevo 
        //public string CreateRecipeDetail(BusinessEntities.RecetaEnt nuevoDetalle)
        //{
        //    using (var scope = new TransactionScope())
        //    {
        //        var detalleReceta = new Receta
        //        {
        //            IdReceta = nuevoDetalle.IdReceta,
        //            IdProducto = nuevoDetalle.IdProducto,
        //            Cantidad = nuevoDetalle.Cantidad,
        //            Precio = nuevoDetalle.Precio,
        //            IdSucursal = nuevoDetalle.IdSucursal
        //        };
        //        _unitOfWork.RepositorioReceta.Insert(detalleReceta);
        //        _unitOfWork.Save();
        //        scope.Complete();
        //        return "Detalle registrado exitosamente!";
        //    }
        //}

        ////Metod que modifica un detalle de receta especifico
        //public string UpdateRecipeDetail(long idProducto, long idReceta, short idSucursal, BusinessEntities.RecetaEnt detailToUpdate)
        //{
        //    using (var scope = new TransactionScope())
        //    {
        //        Func<Receta, Boolean> param = x => { if ((x.IdProducto == idProducto) && (x.IdReceta == idReceta) && (x.IdSucursal == idSucursal)) return true; else return false; };

        //        var detalle = _unitOfWork.RepositorioReceta.Get(param);
        //        if (detalle != null)
        //        {
        //            detalle.IdReceta = detailToUpdate.IdReceta;
        //            detalle.IdProducto = detailToUpdate.IdProducto;
        //            detalle.Cantidad = detailToUpdate.Cantidad;
        //            detalle.Precio = detailToUpdate.Precio;
        //            detalle.IdSucursal = detailToUpdate.IdSucursal;

        //            _unitOfWork.RepositorioReceta.Update(detalle);
        //            _unitOfWork.Save();
        //            scope.Complete();

        //            return "Detalle modificado exitosamente!";
        //        }
        //        else
        //            return "El detalle de receta indicado no se encuentra registrado, por favor vuelva a intentarlo.";
        //    }
        //}

        ////Retorna todos los detalles de recetas registrados en la bd
        //public IEnumerable<BusinessEntities.RecetaEnt> GetAllRecipeDetails()
        //{
        //    var detalleReceta = _unitOfWork.RepositorioReceta.GetAll().ToList();
        //    if (detalleReceta.Any())
        //    {
        //        var config = new MapperConfiguration(cfg =>
        //        {
        //            cfg.CreateMap<Receta, BusinessEntities.RecetaEnt>();
        //        });

        //        IMapper mapper = config.CreateMapper();
        //        var modeloDetalle = mapper.Map<List<Receta>, List<BusinessEntities.RecetaEnt>>(detalleReceta);
        //        return modeloDetalle;
        //    }
        //    return null;
        //}
    }
}
