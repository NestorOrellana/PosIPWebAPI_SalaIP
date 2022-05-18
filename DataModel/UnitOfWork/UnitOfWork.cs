#region Using Namespaces...

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity.Validation;
using System.Data.Entity;
using DataModel.GenericRepository;

#endregion

namespace DataModel.UnitOfWork
{
    /// <summary>
    /// Esta clase es la responsable de las transacciones para la base de datos.
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables...

        private readonly ComercializacionDIPEntities _context = null;
        private GenericRepository<Usuarios> _repositorioUsuario;
        private GenericRepository<FacturaE> _repositorioFactura;
        private GenericRepository<Sucursal> _repositorioSucursal;
        private GenericRepository<TipoUsuario> _repositorioTipoUsuaio;
        private GenericRepository<Productos> _repositorioProducto;
        private GenericRepository<CajaChica> _repositorioCajaChica;
        private GenericRepository<Categorias> _repositorioCategoria;
        //private GenericRepository<Receta> _repositorioReceta;
        //private GenericRepository<Plu> _repositorioPlu;
        private GenericRepository<Series> _repositorioFact;
        private GenericRepository<MotivosInventario> _repositorioMInventario;
        private GenericRepository<FacturaE> _repositorioFacturaE;
        private GenericRepository<DetalleFactura> _repositorioDetalleFact;
        private GenericRepository<DetallePluAdquirido> _repositorioDetallePluAd;
        private GenericRepository<WsGetPedidosHoyJSON_Result> _repositorioSPGetPedidos;
        private GenericRepository<ConversionesProductos> _repositorioConversiones;
        private GenericRepository<VistaPLU> _repositorioVistaPlu;
        private GenericRepository<VistaReceta> _repositorioVistaReceta;
        private GenericRepository<RegistroSincronizacion> _repositorioRegistroSinc;
        private GenericRepository<PedidosRecibidos> _repositorioPedidosRecibidos;
        private GenericRepository<MovimientoInventario> _repositorioMovimientoInventario;
        #endregion

        public UnitOfWork()
        {
            _context = new ComercializacionDIPEntities();
        }

        #region Creacion publilca de las propiedades de repositorios

        /// <summary>
        /// Propiedades Get/Set del repositorio de Usuarios.
        /// </summary>
        public GenericRepository<Usuarios> RepositorioUsuario
        {
            get
            {
                if (this._repositorioUsuario == null)
                    this._repositorioUsuario = new GenericRepository<Usuarios>(_context);
                return _repositorioUsuario;
            }
        }

        public GenericRepository<PedidosRecibidos> RepositorioPedidosRecibidos
        {
            get
            {
                if (this._repositorioPedidosRecibidos == null)
                    this._repositorioPedidosRecibidos = new GenericRepository<PedidosRecibidos>(_context);
                return _repositorioPedidosRecibidos;
            }
        }

        /// <summary>
        /// Propiedades Get/Set del repositorio de RegistroSincronizacion
        /// </summary>
        public GenericRepository<RegistroSincronizacion> RepositorioRegistroSinc
        {
            get
            {
                if (this._repositorioRegistroSinc == null)
                    this._repositorioRegistroSinc = new GenericRepository<RegistroSincronizacion>(_context);
                return _repositorioRegistroSinc;
            }
        }

        /// <summary>
        /// Propiedades Get/Set del repositorio de Factura.
        /// </summary>
        public GenericRepository<FacturaE> RepositorioFactura
        {
            get
            {
                if (this._repositorioFactura == null)
                    this._repositorioFactura = new GenericRepository<FacturaE>(_context);
                return _repositorioFactura;
            }
        }

        /// <summary>
        /// Propiedades Get/Set del repositorio de Sucursal.
        /// </summary>
        public GenericRepository<Sucursal> RepositorioSucursal
        {
            get
            {
                if (this._repositorioSucursal == null)
                    this._repositorioSucursal = new GenericRepository<Sucursal>(_context);
                return _repositorioSucursal;
            }
        }

        /// <summary>
        /// Propiedades Get/Set del repositorio de Tipo de Usuario.
        /// </summary>
        public GenericRepository<TipoUsuario> RepositorioTipoUsuario
        {
            get
            {
                if (this._repositorioTipoUsuaio == null)
                    this._repositorioTipoUsuaio = new GenericRepository<TipoUsuario>(_context);
                return _repositorioTipoUsuaio;
            }
        }

        /// <summary>
        /// Propiedades Get/Set del repositorio de Productos.
        /// </summary>
        public GenericRepository<Productos> RepositorioProducto
        {
            get
            {
                if (this._repositorioProducto == null)
                    this._repositorioProducto = new GenericRepository<Productos>(_context);
                return _repositorioProducto;
            }
        }

        public GenericRepository<CajaChica> RepositorioCajaChica
        {
            get
            {
                if (this._repositorioCajaChica == null)
                    this._repositorioCajaChica = new GenericRepository<CajaChica>(_context);
                return _repositorioCajaChica;
            }
        }

        public GenericRepository<Categorias> RepositorioCategoria
        {
            get
            {
                if (this._repositorioCajaChica == null)
                    this._repositorioCategoria = new GenericRepository<Categorias>(_context);
                return _repositorioCategoria;
            }
        }

        //public GenericRepository<Receta> RepositorioReceta
        //{
        //    get
        //    {
        //        if (this._repositorioReceta == null)
        //            this._repositorioReceta = new GenericRepository<Receta>(_context);
        //        return _repositorioReceta;
        //    }
        //}

        //public GenericRepository<Plu> RepositorioPlu
        //{
        //    get
        //    {
        //        if (this._repositorioPlu == null)
        //            this._repositorioPlu = new GenericRepository<Plu>(_context);
        //        return _repositorioPlu;
        //    }
        //}

        public GenericRepository<Series> RepositorioFactS
        {
            get
            {
                if (this._repositorioFact == null)
                    this._repositorioFact = new GenericRepository<Series>(_context);
                return _repositorioFact;
            }
        }

        public GenericRepository<MotivosInventario> RepositorioMInventario
        {
            get
            {
                if (this._repositorioMInventario == null)
                    this._repositorioMInventario = new GenericRepository<MotivosInventario>(_context);
                return _repositorioMInventario;
            }
        }

        public GenericRepository<FacturaE> RepositorioFacturaE
        {
            get
            {
                if (this._repositorioFacturaE == null)
                    this._repositorioFacturaE = new GenericRepository<FacturaE>(_context);
                return _repositorioFacturaE;
            }
        }

        public GenericRepository<DetalleFactura> RepositorioDetalleFact
        {
            get
            {
                if (this._repositorioDetalleFact == null)
                    this._repositorioDetalleFact = new GenericRepository<DetalleFactura>(_context);
                return _repositorioDetalleFact;
            }
        }

        public GenericRepository<DetallePluAdquirido> RepositorioDetallePluAd
        {
            get
            {
                if (this._repositorioDetallePluAd == null)
                    this._repositorioDetallePluAd = new GenericRepository<DetallePluAdquirido>(_context);
                return _repositorioDetallePluAd;
            }
        }

        public GenericRepository<WsGetPedidosHoyJSON_Result> RepositorioPedidos
        {
            get
            {
                if (this._repositorioSPGetPedidos == null)
                    this._repositorioSPGetPedidos = new GenericRepository<WsGetPedidosHoyJSON_Result>(_context);
                return _repositorioSPGetPedidos;
            }
        }

        public GenericRepository<ConversionesProductos> RepositorioConversiones
        {
            get
            {
                if (this._repositorioConversiones == null)
                    this._repositorioConversiones = new GenericRepository<ConversionesProductos>(_context);
                return _repositorioConversiones;
            }
        }

        public GenericRepository<VistaPLU> RepositorioVistaPlu
        {
            get
            {
                if (this._repositorioVistaPlu == null)
                    this._repositorioVistaPlu = new GenericRepository<VistaPLU>(_context);
                return _repositorioVistaPlu;
            }
        }

        public GenericRepository<VistaReceta> RepositorioVistaReceta
        {
            get
            {
                if (this._repositorioVistaReceta == null)
                    this._repositorioVistaReceta = new GenericRepository<VistaReceta>(_context);
                return _repositorioVistaReceta;
            }
        }

        public GenericRepository<MovimientoInventario> RepositorioMovimientoInventario
        {
            get
            {
                if (this._repositorioMovimientoInventario == null)
                    this._repositorioMovimientoInventario = new GenericRepository<MovimientoInventario>(_context);
                return _repositorioMovimientoInventario;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Metodo de Guardado
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Metodo protegido de deshecho virtual
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("Unidad de trabajo deshechada");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Metodo de deshecho
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}