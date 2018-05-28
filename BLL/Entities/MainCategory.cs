using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
   public class MainCategory:AbstractCategory
    {
        public MainCategory()
        {
            SubCategorys = new List<SubCategory>();
        }

        public override int ID { get; set; }
        public override string Name { get; set; }

        public ICollection<SubCategory> SubCategorys { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
