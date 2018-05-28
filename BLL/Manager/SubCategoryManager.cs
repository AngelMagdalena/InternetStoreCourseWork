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
  public  class SubCategoryManager:ISubCategoryManager
    {
        IKernel ninject;
        IUnitOfWork Db;

        public SubCategoryManager()
        {
            ninject = new StandardKernel();
            ninject.Bind<IUnitOfWork>().To<UnitOfWork>();
            Db = ninject.Get<IUnitOfWork>();
        }

        public SubCategoryManager(IUnitOfWork _db)
        {
            Db = _db;
        }

        public bool CheckTitle(string title)
        {
            IEnumerable<DbSubCategory> categories = Db.SubCategorys.GetAll();
            foreach (DbSubCategory c in categories)
            {
                if (c.Name == title) return true;
            }
            return false;
        }

        public void CreateSubCategory(SubCategory item, MainCategory m_cat)
        {
            MainCategory category = Mapper.Map<DbMainCategory, MainCategory>(Db.MainCategorys.GetItem(m_cat.ID));
            var newSubCat = new DbSubCategory()
            {
                Name = item.Name,
                Category = Db.MainCategorys.GetItem(m_cat.ID),
                CategoryID = m_cat.ID
            };

            Db.SubCategorys.Create(newSubCat);
            category.SubCategorys.Add(item);
            Db.SubCategorys.Update(newSubCat);
            Db.Save();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public void EditSubCategory(SubCategory item, MainCategory m_cat)
        {
            var newSubCategory = new DbSubCategory()
            {
                Name = item.Name,
                Category = Db.MainCategorys.GetItem(m_cat.ID),
                CategoryID = m_cat.ID
            };

            Db.MainCategorys.Update(Db.MainCategorys.GetItem(item.CategoryID));
            Db.SubCategorys.Update(newSubCategory);
            Db.Save();
        }

        public List<SubCategory> GetAllSubCategories()
        {
            return Mapper.Map<IEnumerable<DbSubCategory>, List<SubCategory>>(Db.SubCategorys.GetAll());
        }

        public SubCategory GetSubCategory(int id)
        {
            return Mapper.Map<DbSubCategory, SubCategory>(Db.SubCategorys.GetItem(id));
        }

        public void RemoveSubCategory(int id)
        {
            SubCategory sub_cat = Mapper.Map<DbSubCategory, SubCategory>(Db.SubCategorys.GetItem(id));

            if (sub_cat == null)
            {
                throw new ArgumentNullException();
            }

            MainCategory main_cat = Mapper.Map<DbMainCategory, MainCategory>(Db.MainCategorys.GetItem(sub_cat.CategoryID));
            main_cat.SubCategorys.Remove(sub_cat);
            Db.MainCategorys.Update(Db.MainCategorys.GetItem(sub_cat.CategoryID));
            Db.SubCategorys.Delete(id);
        }
    }

}
}
