using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
   public  interface IMainCategoryManager
    {
        void CreateMainCategory(MainCategory m_cat);
        bool CheckTitle(string title);
        void RemoveMainCategory(int id);
        void EditMainCategory(MainCategory entity);
        List<MainCategory> GetAllMainCategories();
        MainCategory GetMainCategory(int id);
        void Dispose();


    }
}
