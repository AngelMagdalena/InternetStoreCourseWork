using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
   public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public string Code { get; set; }
        public int Size { get; set; }
        public string Colour { get; set; }
        public string Material { get; set; }
        public string Brend { get; set; }
        public string Season { get; set; }
        public int CountOrder { get; set; }

        public int AuthorID { get; set; }
        public User Author { get; set; }

        public int SubCategoryID { get; set; }
        public SubCategory SubCategory { get; set; }

        public DateTime DatePublication { get; set; }

        public decimal Price { get; set; }

    }
}
