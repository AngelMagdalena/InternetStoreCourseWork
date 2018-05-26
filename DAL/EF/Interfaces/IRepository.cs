using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Interfaces
{
    public interface IRepository<Type> : IDisposable
        where Type : class
    {
        IEnumerable<Type> GetAll();
        Type GetItem(int ID);
        void Create(Type item);
        void Update(Type item);
        void Delete(int ID);
        void Save();
        IEnumerable<Type> Find(Func<Type, Boolean> predicate);
    }
}
