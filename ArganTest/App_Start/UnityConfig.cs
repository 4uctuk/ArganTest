using System.Web.Mvc;
using ArganTest.Features.DataAccess.Repositories;
using Unity;
using Unity.Mvc5;

namespace ArganTest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            container.RegisterType<ITestCategoryRepository, TestCategoryRepository>();
            container.RegisterType<ITestOrderRepository, TestOrderRepository>();
            container.RegisterType<ITestOrderProductRepository, TestOrderProductRepository>();
            container.RegisterType<ITestProductRepository, TestProductRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}