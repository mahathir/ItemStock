using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ItemStock.Api.Auth;
using ItemStock.DTO.Implementation;
using ItemStock.DTO.Interface;
using ItemStock.Repository.Interface;
using Microsoft.AspNet.Identity;

namespace ItemStock.Api.Controllers
{
    [Authorize]
    public class UserController : BaseApiController, IBaseController<AppUser>
    {
        private IAppUserRepository _userRepository;
        private IAuthRepository _authRepo;

        public UserController(IAppUserRepository userRepository, IAuthRepository authRepo)
        {
            _userRepository = userRepository;
            _authRepo = authRepo;
        }

        [ResponseType(typeof(ICollection<AppUser>))]
        public async Task<IHttpActionResult> Get()
        {
            var userList = _userRepository.FindAll().Cast<AppUser>().ToList();
            return Ok<ICollection<AppUser>>(userList);
        }

        [ResponseType(typeof(AppUser))]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var user = _userRepository.Find(id) as AppUser;
            return Ok<AppUser>(user);
        }

        [ResponseType(typeof(AppUser))]
        public async Task<IHttpActionResult> Put(AppUser user)
        {
            var currentUser = _userRepository.Find(user.Id) as AppUser;

            if (currentUser != null)
            {
                currentUser.Name = user.Name;
                currentUser.LastModifiedDateTime = DateTime.Now;

                _userRepository.Update(currentUser);
                return Ok<AppUser>(currentUser);
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseType(typeof(AppUser))]
        public async Task<IHttpActionResult> Post(AppUser user)
        {
            if (user == null) return BadRequest();

            var existingUser = _userRepository.FindByUsername(user.Username);
            if (existingUser != null)
            {
                return BadRequest();
            }

            user.Id = Guid.NewGuid();
            user.CreatedDateTime = DateTime.Now;

            _userRepository.Add(user);
            var addedUser = _userRepository.Find(user.Id);

            var result = await _authRepo.RegisterUser(user);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                _userRepository.Delete(addedUser);
                return errorResult;
            }

            return Ok<AppUser>(addedUser as AppUser);
        }

        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var entity = _userRepository.Find(id);

            if (entity != null)
            {
                await _authRepo.DeleteUser(entity.Username);
                _userRepository.Delete(entity);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
