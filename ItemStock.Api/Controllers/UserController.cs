using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ItemStock.Api.Identity.UserStore;
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

        public async Task<ICollection<AppUser>> Get()
        {
            return _userRepository.FindAll().Cast<AppUser>().ToList();
        }

        public async Task<AppUser> Get(Guid id)
        {
            return _userRepository.Find(id) as AppUser;
        }

        public async Task Put(AppUser user)
        {
            var currentUser = _userRepository.Find(user.Id) as AppUser;

            if (currentUser != null)
            {
                currentUser.Name = user.Name;
                currentUser.LastModifiedDateTime = DateTime.Now;

                _userRepository.Update(currentUser);
            }
        }

        public async Task Post(AppUser user)
        {
            if (user == null) return;

            var existingUser = _userRepository.FindByUsername(user.Username);
            if (existingUser != null) return;

            user.Id = Guid.NewGuid();
            user.CreatedDateTime = DateTime.Now;

            _userRepository.Add(user);

            var userIdentity = new AppUserIdentity()
            {
                UserName = user.Username,
                AppUserId = user.Id
            };
            var adminresult = await UserManager.CreateAsync(userIdentity, user.Password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = await UserManager.AddToRoleAsync(userIdentity.Id, "Admin");
            }
        }

        public async Task Delete(Guid id)
        {
            var entity = _userRepository.Find(id);
            if (entity != null)
            {
                var userIdentity = await UserManager.FindByNameAsync(entity.Username);
                await UserManager.DeleteAsync((AppUserIdentity)userIdentity);
                _userRepository.Delete(entity);
            }
        }
    }
}
