using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;
using Ninject;
using DAL;
using DAL.EF;
using DAL.EF.Interfaces;
using DAL.EF.Entities;
using AutoMapper;
using System.Text.RegularExpressions;

namespace BLL.Manager
{
    public class ProductManager:IProductManager
    {
        string regexp = (@"^/d{6}$");
        IKernel ninject;
        IUnitOfWork Db;

        public ProductManager()
        {
            ninject = new StandardKernel();
            ninject.Bind<IUnitOfWork>().To<UnitOfWork>();
            Db = ninject.Get<IUnitOfWork>();
        }

        public ProductManager(IUnitOfWork _db)
        {
            Db = _db;
        }

        public void CreateProduct(Product product, User user, SubCategory sub_cat)
        {
            SubCategory category = Mapper.Map<DbSubCategory, SubCategory>(Db.SubCategorys.GetItem(sub_cat.ID));
            var newProduct = new DbProduct()
            {
                Name = product.Name,
                Size = product.Size,
                Photo = product.Photo,
                Colour = product.Colour,
                Material = product.Material,
                Brend = product.Brend,
                Season = product.Season,
                Price = product.Price,
                SubCategory = Db.SubCategorys.GetItem(sub_cat.ID),
                SubCategoryID = sub_cat.ID
            };

            Db.Products.Create(newProduct);
            category.Products.Add(product);
            Db.Products.Update(newProduct);
            Db.Save();
        }

        public void RemoveProduct(int id)
        {
            Product product = Mapper.Map<DbProduct, Product>(Db.Products.GetItem(id));

            if (product == null)
            {
                throw new ArgumentNullException();
            }

            SubCategory category = Mapper.Map<DbSubCategory, SubCategory>(Db.SubCategorys.GetItem(product.SubCategoryID));
            category.Products.Remove(product);
            Db.SubCategorys.Update(Db.SubCategorys.GetItem(product.SubCategoryID));
            Db.Products.Delete(id);
        }

        public bool CheckCode(string code)
        {
            IEnumerable<DbProduct> products = Db.Products.GetAll();
            if (Regex.IsMatch(code, regexp))
            {
                foreach (DbProduct p in products)
                {
                    if (p.Code == code) return true;
                }
            }

            return false;
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public void EditProduct(Product product, SubCategory sub_cat)
        {
            var newProduct = new DbProduct()
            {
                Name = product.Name,
                Size = product.Size,
                Photo = product.Photo,
                Colour = product.Colour,
                Material = product.Material,
                Brend = product.Brend,
                Season = product.Season,
                Price = product.Price,
                SubCategory = Db.SubCategorys.GetItem(sub_cat.ID),
                SubCategoryID = sub_cat.ID
            };

            Db.SubCategorys.Update(Db.SubCategorys.GetItem(product.SubCategoryID));
            Db.Products.Update(newProduct);
            Db.Save();
        }

        public List<Product> Filter(IEnumerable<Product> Products, Product Product)
        {
            List<Product> prod = new List<Product>();
            foreach (Product p in Products)
            {
                if (p == Product)
                    prod.Add(p);
            }
            return prod;
        }

        public List<Product> GetAllProducts()
        {
            return Mapper.Map<IEnumerable<DbProduct>, List<Product>>(Db.Products.GetAll());
        }

        public Product GetProduct(int id)
        {
            return Mapper.Map<DbProduct, Product>(Db.Products.GetItem(id));
        }
    }
}

    }
}
