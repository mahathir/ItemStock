using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemStock.Api.Controllers
{
    public interface IBaseController<Entity>
        where Entity : class
    {
        ICollection<Entity> Get();

        Entity Get(Guid id);

        void Put(Entity entity);

        void Post(Entity entity);

        void Delete(Guid id);
    }
}