using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.EF;
using DAL.EF.Interfaces;

namespace DAL
{
    class Repository<Type> : IRepository<Type>
        where Type : class
    {
        private StoreContext db;
        private bool disposed = false;

        public Repository()
        {
            this.db = new StoreContext();
        }

        public virtual IEnumerable<Type> Get()
        {
            return db.Set<Type>().AsNoTracking().ToList();
        }

        public virtual IEnumerable<Type> GetAll()
        {
            IQueryable<Type> query = db.Set<Type>();
            return query.ToList();
        }

        public Type GetItem(int ID)
        {
            Type item = db.Set<Type>().Find(ID);
            if (item != null)
            {
                return item;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void Create(Type item)
        {
            db.Set<Type>().Add(item);
            Save();
        }

        public void Update(Type item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int ID)
        {
            Type item = db.Set<Type>().Find(ID);
            if (item != null)
            {
                db.Set<Type>().Remove(item);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Type> Find(Func<Type, Boolean> predicate)
        {
            return db.Set<Type>().Where(predicate).ToList();
        }
    }
}
