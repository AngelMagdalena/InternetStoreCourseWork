using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;


namespace BLL.Interfaces
{
  public interface IUserGroupManager
    {
        void CreateUserGroup(UserGroup user_group);
        void EditUserGroup(UserGroup user_group);
        void RemoveUserGroup(int id);
        UserGroup GetUserGroup(int id);

        void Dispose();
    }
}
