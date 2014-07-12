using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ItemStock.Api.Controllers
{
    public interface IBaseController<Entity>
        where Entity : class
    {
        Task<IHttpActionResult> Get();

        Task<IHttpActionResult> Get(Guid id);

        Task<IHttpActionResult> Put(Entity entity);

        Task<IHttpActionResult> Post(Entity entity);

        Task<IHttpActionResult> Delete(Guid id);
    }
}