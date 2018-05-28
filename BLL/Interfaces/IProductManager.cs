using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
   public interface IProductManager
    {
        void CreateProduct(Product product, User author, SubCategory sub_category);
        void EditProduct(Product product, SubCategory sub_cat);
        void RemoveProduct(int id);
        bool CheckCode(string code);
        Product GetProduct(int id);
        List<Product> Filter(IEnumerable<Product> Products, Product Product);
        List<Product> GetAllProducts();
        void Dispose();
    }
}
