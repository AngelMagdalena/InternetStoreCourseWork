using System.Collections.Generic;

namespace DAL.EF.Entities
{
    public class DbMainCategory : DbAbstractCategory
    {
        public DbMainCategory()
        {
            SubCategorys = new List<DbSubCategory>();
        }
        
        public override int ID { get; set; }
        
        //[RegularExpression(pattern: @"^[A-ZА-ЯЪ]+[a-zа-яъA-ZА-ЯЪ\-\s]*$", ErrorMessage = "Название должно быть с большой буквы, и может содержать только буквы, пробелы,тире")]
        public override string Name { get; set; }

        // Ссылка на подкатегории
        public ICollection<DbSubCategory> SubCategorys { get; set; }
    }
}
