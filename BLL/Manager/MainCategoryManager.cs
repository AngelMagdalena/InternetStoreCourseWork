using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Entities;
using DAL.EF.Entities;
using Ninject;
using DAL.EF.Interfaces;
using AutoMapper;
using DAL;

namespace BLL.Manager
{
  public  class MainCategoryManager:IMainCategoryManager
    {
        IKernel ninject;
        IUnitOfWork Db { get; set; }

        public MainCategoryManager()
        {
            ninject = new StandardKernel();
            ninject.Bind<IUnitOfWork>().To<UnitOfWork>();
            Db = ninject.Get<IUnitOfWork>();
        }

        public MainCategoryManager(IUnitOfWork _db)
        {
            Db = _db;
        }

        public bool CheckTitle(string title)
        {
            IEnumerable<DbMainCategory> categories = Db.MainCategorys.GetAll();
            foreach (DbMainCategory cat in categories)
            {
                return (cat.Name == title);
            }
            return false;
        }

        public void CreateMainCategory(MainCategory m_cat)
        {
            if (m_cat == null)
            {
                throw new ArgumentNullException();
            }

            DbMainCategory new_m_cat = new DbMainCategory
            {
                Name = m_cat.Name
            };

            Db.MainCategorys.Create(new_m_cat);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public void EditMainCategory(MainCategory entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            DbMainCategory tmp = new DbMainCategory
            {
                Name = entity.Name
            };

            Db.MainCategorys.Update(tmp);
            Db.Save();
        }

        public List<MainCategory> GetAllMainCategories()
        {
            return Mapper.Map<IEnumerable<DbMainCategory>, List<MainCategory>>(Db.MainCategorys.GetAll());
        }

        public MainCategory GetMainCategory(int id)
        {
            return Mapper.Map<DbMainCategory, MainCategory>(Db.MainCategorys.GetItem(id));
        }

        public void RemoveMainCategory(int id)
        {
            DbMainCategory m_cat = Db.MainCategorys.GetItem(id);
            if (m_cat == null)
            {
                throw new ArgumentNullException();
            }

            Db.SubCategorys.Delete(id);
            foreach (DbSubCategory s_cat in m_cat.SubCategorys)
            {
                s_cat.Category = null;
                s_cat.CategoryID = -1;
            }
            Db.Save();
        }
    }

}
}
