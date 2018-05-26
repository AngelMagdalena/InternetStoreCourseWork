using System.Collections.Generic;

namespace DAL.EF.Entities
{
    public class DbSubCategory : DbAbstractCategory
    {
        public DbSubCategory()
        {
            Products = new List<DbProduct>();
        }
        
        public override int ID { get; set; }
        
        //[RegularExpression(pattern: @"^[A-ZА-ЯЪ]+[a-zа-яъA-ZА-ЯЪ\-\s]*$", ErrorMessage = "Название должно быть с большой буквы, и может содержать только буквы, пробелы,тире")]
        public override string Name { get; set; }

        // Ссылка на категорию
        public int CategoryID { get; set; }
        public DbMainCategory Category { get; set; }

        // Ссылка на заказы
        public virtual ICollection<DbProduct> Products { get; set; }
    }
}
