using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Entities
{
    public class DbProduct
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public byte[] Photo { get; set; }

        public string Code { get; set; }
        
        [MaxLength(20)]
        public int Size { get; set; } 
        
        [MaxLength(20)]
        public string Colour { get; set; }

        [Required]
        [MaxLength(50)]
        public string Material { get; set; }

        [MaxLength(50)]
        public string Brend { get; set; }

        [MaxLength(50)]
        public string Season { get; set; }

        public int CountOrder { get; set; }

        // Ссылка на автора
        public int UserID { get; set; }
        public DbUser User { get; set; }

        // Ссылка на подкатегорию
        public int SubCategoryID { get; set; }
        public DbSubCategory SubCategory { get; set; }
        
        public DateTime DatePublication { get; set; }
        
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
