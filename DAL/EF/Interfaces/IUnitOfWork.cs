using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Entities;

namespace DAL.EF.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<DbProduct> Products { get; }
        IRepository<DbSubCategory> SubCategorys { get; }
        IRepository<DbMainCategory> MainCategorys { get; }
        IRepository<DbUserGroup> UserGroups { get; }
        IRepository<DbUser> Users { get; }
        void Save();
    }
}
