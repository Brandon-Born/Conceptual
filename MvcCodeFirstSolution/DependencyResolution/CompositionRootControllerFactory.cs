using System.Web.Mvc;
using System.Web.Routing;
using Domain.Abstractions;
using Domain.Entities.ShippingCalculation;
using Infrastructure;
using Infrastructure.Repositories;
using Ninject;
using Ninject.Parameters;

namespace DependencyResolution
{
    public class CompositionRootControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernal;

        public CompositionRootControllerFactory()
        {
            _kernal = GetKernal();
        }

        private IKernel GetKernal()
        {
            var kernal = new StandardKernel();

            kernal.Bind<IDomainContext>().To<DomainContext>().InRequestScope();
            kernal.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernal.Bind<ICategoryRepository>().To<CategoryRepository>().InRequestScope();
            kernal.Bind<IProductRepository>().To<ProductRepository>().InRequestScope();
            kernal.Bind<IShippingService>().To<ShippingService>().InRequestScope().WithConstructorArgument("shippingCalculations", ShippingCalculationFactory.GetShippingCalculations());

            return kernal;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, System.Type controllerType)
        {
            return _kernal.TryGet(controllerType, new IParameter[0]) as IController;
        }

        public override void ReleaseController(IController controller)
        {
            base.ReleaseController(controller);
        }
    }
}
