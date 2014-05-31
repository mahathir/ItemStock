using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ItemStock.Api.Controllers
{
    public interface IBaseController<Entity>
        where Entity : class
    {
        Task<ICollection<Entity>> Get();

        Task<Entity> Get(Guid id);

        Task Put(Entity entity);

        Task Post(Entity entity);

        Task Delete(Guid id);
    }
}