using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
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

        [ResponseType(typeof(ICollection<Good>))]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(_goodRepository.FindAll().Cast<Good>().ToList());
        }

        [ResponseType(typeof(Good))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            return Ok(_goodRepository.Find(id) as Good);
        }

        [ResponseType(typeof(Good))]
        public async Task<IHttpActionResult> Put(Good good)
        {
            if(good == null || good.Id == new Guid())
            {
                return BadRequest();
            }

            var existingGood = _goodRepository.Find(good.Id);

            if(existingGood == null)
            {
                return BadRequest();
            }

            _goodRepository.Update(good);

            return Ok<Good>(good);
        }

        [ResponseType(typeof(Good))]
        public async Task<IHttpActionResult> Post(Good good)
        {
            var user = new AppUser { Id = Guid.NewGuid() };

            good.Id = Guid.NewGuid();
            good.Code = good.Id.ToString();
            good.CreatedUser = user;
            good.CreatedDateTime = DateTime.Now;

            _goodRepository.Add(good);

            return Ok<Good>(good);
        }

        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var entity = _goodRepository.Find(id);
            if (entity != null)
            {
                _goodRepository.Delete(entity);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
