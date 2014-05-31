using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ItemStock.Persistence.Data;

namespace ItemStock.Api.Identity.UserStore
{
    public class AppUserIdentityDbContextInitializer : CreateDatabaseIfNotExists<AppUserIdentityDbContext>
    {
        protected override void Seed(AppUserIdentityDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);


        }

        private void InitializeIdentityForEF(AppUserIdentityDbContext context)
        {
            var UserManager = new UserManager<AppUserIdentity>(new UserStore<AppUserIdentity>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string roleName = "Admin"; 

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(roleName))
            {
                var roleresult = RoleManager.Create(new IdentityRole(roleName));
            }

            //Create User
            foreach (var u in TestData.AppUsers)
            {
                var user = new AppUserIdentity()
                {
                    UserName = u.Username,
                    AppUserId = u.Id
                };
                var adminresult = UserManager.Create(user, u.Password);

                //Add User Admin to Role Admin
                if (adminresult.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, roleName);
                }
            }
        }
    }
}