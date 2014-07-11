using System.Web.Http;
using ItemStock.Api.Auth;
using ItemStock.Persistence;
using ItemStock.Persistence.Data;
using ItemStock.Repository.Implementation;

namespace ItemStock.Api
{
    public static class AuthConfig
    {
        public static async void Register(HttpConfiguration config)
        {
            IAuthRepository repo = new AuthRepository(new AuthContext(), new AppUserRepository(new ItemStockContext()));

            foreach (var appUser in TestData.AppUsers)
            {
                var user = await repo.FindUser(appUser.Username, appUser.Password);

                if (user != null && !string.IsNullOrEmpty(user.Id))
                {
                    await repo.DeleteUser(appUser.Username);
                }
                await repo.RegisterUser(appUser);
            }
        }
    }
}