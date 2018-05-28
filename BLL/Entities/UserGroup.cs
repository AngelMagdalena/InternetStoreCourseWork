using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
   public class UserGroup
    {
        public UserGroup()
        {
            Users = new List<User>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Access { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
