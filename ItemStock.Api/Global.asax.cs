using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ItemStock.Api.Identity.UserStore;

namespace ItemStock.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DependencyConfig.Register(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.EnsureInitialized();

            Database.SetInitializer<AppUserIdentityDbContext>(new AppUserIdentityDbContextInitializer());

            AppUserIdentityDbContext db = new AppUserIdentityDbContext();
            db.Database.Initialize(true);
        }
    }
}
