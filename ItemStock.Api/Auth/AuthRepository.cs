using System;
using System.Threading.Tasks;
using ItemStock.DTO.Implementation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ItemStock.Repository.Interface;

namespace ItemStock.Api.Auth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AuthContext _authContext;
        private readonly IAppUserRepository _userRepo;

        private readonly UserManager<IdentityUser> _userManager;

        public AuthRepository(AuthContext authContext, IAppUserRepository userRepo)
        {
            _authContext = authContext;
            _userRepo = userRepo;
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_authContext));
        }

        public async Task<IdentityResult> RegisterUser(AppUser userModel)
        {
            var user = new IdentityUser
            {
                UserName = userModel.Username
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (result.Succeeded)
            {
                _userRepo.Add(userModel);
            }

            return result;
        }

        public async Task<IdentityResult> DeleteUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                var userDb = _userRepo.FindByUsername(username);
                _userRepo.Delete(userDb);
            }

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _authContext.Dispose();
            _userManager.Dispose();
        }
    }

    public interface IAuthRepository : IDisposable
    {
        Task<IdentityResult> RegisterUser(AppUser userModel);

        Task<IdentityResult> DeleteUser(string username);

        Task<IdentityUser> FindUser(string userName, string password);
    }
}
