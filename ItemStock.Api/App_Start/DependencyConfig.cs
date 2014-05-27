using System.Data.Entity;
using System.Web.Http;
using ItemStock.Api.DI;
using ItemStock.Persistence;
using ItemStock.Repository;
using ItemStock.Repository.Implementation;
using ItemStock.Repository.Interface;
using SimpleInjector;

namespace ItemStock.Api
{
    public static class DependencyConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // 1. Create a new Simple Injector container
            var container = new Container();

            // 2. Configure the container (register)
            container.Register<IGoodRepository, GoodRepository>();
            container.Register<IAppUserRepository, AppUserRepository>();
            container.Register<DbContext, ItemStockContext>();

            // 3. Optionally verify the container's configuration.
            container.Verify();

            // 4. Register the container as MVC3 IDependencyResolver.
            config.DependencyResolver = new SimpleInjectorHttpDependencyResolver(container);
        }
    }
}