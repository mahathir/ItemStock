using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Interface;

namespace ItemStock.Repository.Interface
{
    public interface IAppUserRepository
    {
        void Add(IAppUser user);

        void Update(IAppUser user);

        void Delete(IAppUser user);

        IAppUser Find(Guid id);

        ICollection<IAppUser> FindAll();

        IAppUser FindByUsername(string username);
    }
}
