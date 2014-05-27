using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ItemStock.Api.Startup))]
namespace ItemStock.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
