using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ItemStock.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            DependencyConfig.Register(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
