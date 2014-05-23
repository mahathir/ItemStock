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
    public class LocalFileRepository : BaseRepository<ILocalFile, LocalFile, Guid>, ILocalFileRepository
    {
        public LocalFileRepository(DbContext context)
            : base(context)
        {
        }

        public override void Add(ILocalFile file)
        {
            base.Add(file);
            SaveChanges();
        }

        public override void Update(ILocalFile file)
        {
            base.Update(file);
            SaveChanges();
        }

        public override void Delete(ILocalFile file)
        {
            base.Delete(file);
            SaveChanges();
        }

        public ILocalFile FindByName(string name)
        {
            return DbSet.Where(a => a.Name == name).FirstOrDefault();
        }
    }
}
