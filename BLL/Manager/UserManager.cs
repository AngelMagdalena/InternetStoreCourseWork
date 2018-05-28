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
    public class UserManager : IUserManager
    {
        IKernel ninject;
        IUnitOfWork Db;

        public UserManager()
        {
            ninject = new StandardKernel();
            ninject.Bind<IUnitOfWork>().To<UnitOfWork>();
            Db = ninject.Get<IUnitOfWork>();
        }

        public bool Buying(Product Product, int user_id)
        {
            throw new NotImplementedException();
        }

        public bool CheckUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user, UserGroup user_group)
        {
            /*
            UserGroup usergroup = Mapper.Map<DbUserGroup, UserGroup>(Db.UserGroups.GetItem(user_group.ID));
            SubCategory category = Mapper.Map<DbSubCategory, SubCategory>(Db.SubCategorys.GetItem(sub_cat.ID));
            var newUser = new DbUser()
            {
                Name = user.Name;
            };

            Db.Products.Create(newProduct);
            category.Products.Add(product);
            Db.Products.Update(newProduct);
            Db.Save();
            */
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public void EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            return Mapper.Map<DbUser, User>(Db.Users.GetItem(id));
        }

        public void RemoveUser(int id)
        {
            User user = Mapper.Map<DbUser, User>(Db.Users.GetItem(id));

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            UserGroup group = Mapper.Map<DbUserGroup, UserGroup>(Db.UserGroups.GetItem(user.UserGroupID));
            group.Users.Remove(user);
            Db.Users.Delete(id);
            
        }

        public bool Reserving(Product Product, int user_id)
        {
            throw new NotImplementedException();
        }
    }
}
