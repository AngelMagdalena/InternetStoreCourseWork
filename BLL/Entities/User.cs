using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
   public class User
    {
        public int ID { get; set; }

        public int UserGroupID { get; set; }
        public UserGroup UserGroup { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Money { get; set; }

        public virtual ICollection<Product> AuctionProducts { get; set; }
        public virtual ICollection<Product> BoughtProducts { get; set; }
        public virtual ICollection<Product> AddedProducts { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
