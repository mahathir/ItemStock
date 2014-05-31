using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ItemStock.DTO.Implementation;
using ItemStock.DTO.Interface;
using ItemStock.Repository.Interface;

namespace ItemStock.Api.Controllers
{
    [Authorize]
    public class GoodController : BaseApiController, IBaseController<Good>
    {
        private IGoodRepository _goodRepository;

        public GoodController(IGoodRepository goodRepository)
        {
            _goodRepository = goodRepository;
        }

        public async Task<ICollection<Good>> Get()
        {
            return _goodRepository.FindAll().Cast<Good>().ToList();
        }

        public async Task<Good> Get(Guid id)
        {
            return _goodRepository.Find(id) as Good;
        }

        public async Task Put(Good good)
        {
            _goodRepository.Update(good);
        }

        public async Task Post(Good good)
        {
            var user = new AppUser { Id = Guid.NewGuid() };

            good.Id = Guid.NewGuid();
            good.Code = good.Id.ToString();
            good.CreatedUser = user;
            good.CreatedDateTime = DateTime.Now;

            _goodRepository.Add(good);
        }

        public async Task Delete(Guid id)
        {
            var entity = _goodRepository.Find(id);
            if (entity != null) _goodRepository.Delete(entity);
        }
    }
}
