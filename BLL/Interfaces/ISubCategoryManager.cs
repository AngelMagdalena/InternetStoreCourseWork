using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
   public interface ISubCategoryManager
    {
        void CreateSubCategory(SubCategory item, MainCategory parent);
        bool CheckTitle(string title);
        void RemoveSubCategory(int id);
        void EditSubCategory(SubCategory item, MainCategory parent);
        List<SubCategory> GetAllSubCategories();
        SubCategory GetSubCategory(int id);
        void Dispose();
    }
}
