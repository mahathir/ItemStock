using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.Owin.Infrastructure;
using Microsoft.AspNet.Identity;
using ItemStock.Api.Identity;

namespace ItemStock.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        private AppUserManager _userManager;
        public AppUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.Request.GetOwinContext().GetUserManager<AppUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        } 
	}
}