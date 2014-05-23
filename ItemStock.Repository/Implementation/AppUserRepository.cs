using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Implementation;
using ItemStock.DTO.Interface;
using ItemStock.Repository.Base;
using ItemStock.Repository.Interface;

namespace ItemStock.Repository.Implementation
{
    public class AppUserRepository : BaseRepository<IAppUser, AppUser, Guid>, IAppUserRepository
    {
        public AppUserRepository(DbContext context)
            : base(context)
        {
        }

        public override void Add(IAppUser user)
        {
            base.Add(user);
            SaveChanges();
        }

        public override void Update(IAppUser user)
        {
            base.Update(user);
            SaveChanges();
        }

        public override void Delete(IAppUser user)
        {
            base.Delete(user);
            SaveChanges();
        }

        public IAppUser FindByUsername(string username)
        {
            return DbSet.Where(a => a.Username == username).FirstOrDefault();
        }
    }
}
