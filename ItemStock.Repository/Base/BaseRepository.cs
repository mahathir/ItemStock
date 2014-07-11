using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemStock.Repository.Base
{
    /// <summary>
    /// Base Repository
    /// </summary>
    /// <typeparam name="I">Repository Interface</typeparam>
    /// <typeparam name="C">Repository Class</typeparam>
    /// <typeparam name="K">Key</typeparam>
    public abstract class BaseRepository<I, C, K>
        where C : class, I
    {
        private DbContext _context;
        public DbContext Context
        {
            get { return _context; }
            set { _context = value; }
        }

        private DbSet<C> _dbSet;
        public DbSet<C> DbSet
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = _context.Set<C>();
                    if (_dbSet == null) throw new InvalidOperationException();
                }

                return _dbSet;
            }
        }

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual void Add(I t)
        {
            _context.Entry<C>(t as C).State = EntityState.Added;
        }

        public virtual void Update(I t)
        {
            _context.Entry<C>(t as C).State = EntityState.Modified;
        }

        public virtual void Delete(I t)
        {
            _context.Entry<C>(t as C).State = EntityState.Deleted;
        }

        public virtual I Find(K key)
        {
            return DbSet.Find(key);
        }

        public virtual ICollection<I> FindAll()
        {
            return DbSet.ToList<I>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
