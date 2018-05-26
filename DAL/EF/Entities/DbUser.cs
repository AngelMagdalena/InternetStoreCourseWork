using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Entities
{
    public class DbUser
    {
        public int ID { get; set; }

        // Ссылка на групу
        public int UserGroupID { get; set; }
        public DbUserGroup UserGroup { get; set; }
        
        //[RegularExpression(pattern: @"^[A-ZА-ЯЪ]+[a-zа-яъA-ZА-ЯЪ\-\s]*$", ErrorMessage = "Имя должно быть с большой буквы, и может содержать только буквы, пробелы,тире")]
        public string Name { get; set; }
        
        //[RegularExpression(pattern: @"^[a-zA-Z0-9._+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$", ErrorMessage = "E-mail может содержать только буквы, цифры, символы _, -, ., +")]
        public string Email { get; set; }
        
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Currency)]
        public decimal Money { get; set; }

        // Ссылка на заказы
        public virtual ICollection<DbProduct> Products { get; set; }
    }
}
