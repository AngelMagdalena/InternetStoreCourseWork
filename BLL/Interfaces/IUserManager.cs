using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;

namespace BLL.Interfaces
{
   public interface IUserManager
    {
        void CreateUser(User user, UserGroup user_group);
        void EditUser(User user);
        void RemoveUser(int id);
        bool CheckUser(string login, string password);
        User GetUser(int id);
        bool Buying(Product Product, int user_id);
        bool Reserving(Product Product, int user_id);

        void Dispose();
    }
}
