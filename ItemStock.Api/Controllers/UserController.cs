using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ItemStock.DTO.Implementation;
using ItemStock.DTO.Interface;
using ItemStock.Repository.Interface;

namespace ItemStock.Api.Controllers
{
    [Authorize]
    public class UserController : BaseApiController, IBaseController<AppUser>
    {
        private IAppUserRepository _userRepository;

        public UserController(IAppUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<AppUser> Get()
        {
            return _userRepository.FindAll().Cast<AppUser>().ToList();
        }

        public AppUser Get(Guid id)
        {
            return _userRepository.Find(id) as AppUser;
        }

        public void Put(AppUser user)
        {
            var currentUser = _userRepository.Find(user.Id) as AppUser;

            if (currentUser != null)
            {
                currentUser.Name = user.Name;
                currentUser.LastModifiedDateTime = DateTime.Now;

                _userRepository.Update(currentUser);
            }
        }

        public void Post(AppUser user)
        {
            user.Id = Guid.NewGuid();
            user.CreatedDateTime = DateTime.Now;

            _userRepository.Add(user);
        }

        public void Delete(Guid id)
        {
            var entity = _userRepository.Find(id);
            if(entity != null) _userRepository.Delete(entity);
        }
    }
}
