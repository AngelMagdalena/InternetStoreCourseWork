using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class SubCategory:AbstractCategory
    {
        public SubCategory()
        {
            Products = new List<Product>();
        }

        public override int ID { get; set; }
        public override string Name { get; set; }
        public int CategoryID { get; set; }
        public MainCategory Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
