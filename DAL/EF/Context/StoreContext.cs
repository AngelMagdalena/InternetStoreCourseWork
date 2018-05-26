using System.Data.Entity;
using DAL.EF.Entities;

namespace DAL.EF
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("IStore")
        { }

        public StoreContext(string connectString) : base(connectString)
        {
            Database.SetInitializer<StoreContext>(new StoreDbInitializer());
        }

        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbUserGroup> UserGroups { get; set; }
        public DbSet<DbProduct> Products { get; set; }
        public DbSet<DbMainCategory> MainCategorys { get; set; }
        public DbSet<DbSubCategory> SubCategorys { get; set; }

        // Переопределяем метод OnModelCreating для добавления
        // настроек конфигурации
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>().HasAlternateKey(user => user.).HasName("AlternateKey_LicensePlate");

            modelBuilder.Configurations.Add(new SubCutegoryConfiguration());
            modelBuilder.Configurations.Add(new MainCategoryConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new UserGroupConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        public class StoreDbInitializer : DropCreateDatabaseAlways<StoreContext>
        {
            protected override void Seed(StoreContext db)
            {
                
            }
        }
    }
}