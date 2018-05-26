using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Entities
{
    public class DbUserGroup
    {
        public DbUserGroup()
        {
            Users = new List<DbUser>();
        }

        public int ID { get; set; }
        
        //[RegularExpression(pattern: @"^[A-ZА-ЯЪ]+[a-zа-яъA-ZА-ЯЪ\-\s]*$", ErrorMessage = "Название должно быть с большой буквы, и может содержать только буквы, пробелы,тире")]
        public string Name { get; set; }
        
        [Range(0, 3)]
        public int Access { get; set; }

        // Ссылка на пользователей
        public virtual ICollection<DbUser> Users { get; set; }
    }
}
