using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.EF.Interfaces;
using DAL.EF.Entities;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private StoreContext db;

        private Repository<DbProduct> products;
        private Repository<DbSubCategory> sub_categorys;
        private Repository<DbMainCategory> main_categorys;
        private Repository<DbUserGroup> user_groups;
        private Repository<DbUser> users;

        private bool disposed = false;

        public UnitOfWork(string connectString)
        {
            db = new StoreContext(connectString);
        }

        public UnitOfWork()
        {
            db = new StoreContext("Auction");
        }

        public IRepository<DbProduct> Products
        {
            get
            {
                if (products == null)
                {
                    products = new Repository<DbProduct>();
                }
                return products;
            }
        }

        public IRepository<DbSubCategory> SubCategorys
        {
            get
            {
                if (sub_categorys == null)
                {
                    sub_categorys = new Repository<DbSubCategory>();
                }
                return sub_categorys;
            }
        }

        public IRepository<DbMainCategory> MainCategorys
        {
            get
            {
                if (main_categorys == null)
                {
                    main_categorys = new Repository<DbMainCategory>();
                }
                return main_categorys;
            }
        }

        public IRepository<DbUserGroup> UserGroups
        {
            get
            {
                if (user_groups == null)
                {
                    user_groups = new Repository<DbUserGroup>();
                }
                return user_groups;
            }
        }

        public IRepository<DbUser> Users
        {
            get
            {
                if (users == null)
                {
                    users = new Repository<DbUser>();
                }
                return users;
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
    }
}
