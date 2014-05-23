using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Interface;

namespace ItemStock.Repository.Interface
{
    public interface ILocalFileRepository
    {
        void Add(ILocalFile file);

        void Update(ILocalFile file);

        void Delete(ILocalFile file);

        ILocalFile Find(Guid id);

        ICollection<ILocalFile> FindAll();

        ILocalFile FindByName(ILocalFile file);
    }
}
