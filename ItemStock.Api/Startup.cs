using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

[assembly: OwinStartup(typeof(ItemStock.Api.Startup))]
namespace ItemStock.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            DependencyConfig.Register(config);
            AuthConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}