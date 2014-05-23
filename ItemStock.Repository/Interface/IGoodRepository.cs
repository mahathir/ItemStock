using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemStock.DTO.Interface;

namespace ItemStock.Repository.Interface
{
    public interface IGoodRepository
    {
        void Add(IGood good);

        void Update(IGood good);

        void Delete(IGood good);

        IGood Find(Guid id);

        ICollection<IGood> FindAll();
    }
}
