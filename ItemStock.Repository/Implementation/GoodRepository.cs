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
    public class GoodRepository : BaseRepository<IGood, Good, Guid>, IGoodRepository
    {
        public GoodRepository(DbContext context)
            : base(context)
        {
        }

        public override void Add(IGood good)
        {
            base.Add(good);
            SaveChanges();
        }

        public override void Update(IGood good)
        {
            base.Update(good);
            SaveChanges();
        }

        public override void Delete(IGood good)
        {
            base.Delete(good);
            SaveChanges();
        }
    }
}
