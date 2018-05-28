using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Interfaces;
using Ninject;
using DAL;
using DAL.EF.Entities;
using DAL.EF.Interfaces;
using AutoMapper;


namespace BLL.Manager
{
   public  class UserGroupManager:IUserGroupManager
    {
        IKernel ninject;
        IUnitOfWork Db;

        public UserGroupManager()
        {
            ninject = new StandardKernel();
            ninject.Bind<IUnitOfWork>().To<UnitOfWork>();
            Db = ninject.Get<IUnitOfWork>();
        }

        public UserGroupManager(IUnitOfWork _db)
        {
            Db = _db;
        }

        public void CreateUserGroup(UserGroup user_group)
        {
            UserGroup u_group = Mapper.Map<DbUserGroup, UserGroup>(Db.UserGroups.GetItem(user_group.ID));
            var newUserGroup = new DbUserGroup()
            {
                Name = user_group.Name,
                Access = user_group.Access
            };

            Db.UserGroups.Create(newUserGroup);
            Db.Save();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public void EditUserGroup(UserGroup user_group)
        {
            var newUserGroup = new DbUserGroup()
            {
                Name = user_group.Name,
                Access = user_group.Access
            };

            Db.UserGroups.Update(newUserGroup);
            Db.Save();
        }

        public UserGroup GetUserGroup(int id)
        {
            return Mapper.Map<DbUserGroup, UserGroup>(Db.UserGroups.GetItem(id));
        }

        public void RemoveUserGroup(int id)
        {
            UserGroup user_group = Mapper.Map<DbUserGroup, UserGroup>(Db.UserGroups.GetItem(id));

            if (user_group == null)
            {
                throw new ArgumentNullException();
            }

            Db.UserGroups.Delete(id);
        }
    }

}
}
