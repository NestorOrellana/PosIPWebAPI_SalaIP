using System.ComponentModel.Composition;
using BusinessServices.Interfaces_de_Servicios;
using BusinessServices.Servicios;
using DataModel;
using DataModel.UnitOfWork;
using Resolver;

namespace BusinessServices
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserServices, UserServices>();
            registerComponent.RegisterType<IProductServices, ProductServices>();
            registerComponent.RegisterType<ISucursalServices, SucursalServices>();
            registerComponent.RegisterType<ICajaChicaServices, CajaChicaServices>();
            registerComponent.RegisterType<ICategoryServices, CategoryServices>();
            //registerComponent.RegisterType<IRecipeServices, RecipeServices>();
            //registerComponent.RegisterType<IPluServices, PluServices>();
            registerComponent.RegisterType<IViewPluServices, ViewPluServices>();
            registerComponent.RegisterType<IViewRecetaServices, ViewRecetaServices>();
            registerComponent.RegisterType<ISFactServices, SFactServices>();
            registerComponent.RegisterType<IMotivosInventarioServices, MotivosInventarioServices>();
            registerComponent.RegisterType<IEncabezadoFacturaServices, EncabezadoFacturaServices>();
            registerComponent.RegisterType<IDetalleFacturaServices, DetalleFacturaServices>();
            registerComponent.RegisterType<IDetallePluAdServices, DetallePluAdServices>();
            registerComponent.RegisterType<ISPGetPedidosServices, SPGetPedidosServices>();
            registerComponent.RegisterType<ISPUpdateCorrelativo, SPUpdateCorrelativo>();
            registerComponent.RegisterType<ITrasladoFacturas, ServiciosTrasladoFacturas>();
            registerComponent.RegisterType<IConversionesProductos, ServiciosConversiones>();
            registerComponent.RegisterType<IRegistroSincServices, RegistroSincServices>();
            registerComponent.RegisterType<IPedidosRecibidosServices, PedidosRecibidosServices>();
            registerComponent.RegisterType<IMovimientoInventario, MovimientoInventarioServices>();
        }
    }
}