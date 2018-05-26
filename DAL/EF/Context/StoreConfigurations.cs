using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.EF.Entities;

namespace DAL.EF
{
    // Настройки для SubCutegory
    public class SubCutegoryConfiguration : EntityTypeConfiguration<DbSubCategory>
    {
        public SubCutegoryConfiguration()
        {
            this.HasKey(prop => prop.ID);
            this.Property(prop => prop.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar");

            this.HasMany(scat => scat.Products)
                .WithRequired(scat => scat.SubCategory)
                .HasForeignKey(scat => scat.SubCategoryID);

            this.ToTable("SubCategory");
        }
    }

    // Настройки для MainCategory
    public class MainCategoryConfiguration : EntityTypeConfiguration<DbMainCategory>
    {
        public MainCategoryConfiguration()
        {
            this.HasKey(prop => prop.ID);
            this.Property(prop => prop.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar");

            this.HasMany(mcat => mcat.SubCategorys)
                .WithRequired(mcat => mcat.Category)
                .HasForeignKey(mcat => mcat.CategoryID);

            this.ToTable("Category");
        }
    }

    // Настройки для Product
    public class ProductConfiguration : EntityTypeConfiguration<DbProduct>
    {
        public ProductConfiguration()
        {
            this.HasKey(prop => prop.ID);
            this.Property(prop => prop.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar");

            this.Property(prop => prop.Code)
                .IsRequired()
                .HasMaxLength(5)
                .HasColumnType("varchar");

            this.Property(prop => prop.Size)
                .IsRequired()
                .HasColumnType("int");

            this.Property(prop => prop.Colour)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar");

            this.Property(prop => prop.Material)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            this.Property(prop => prop.Brend)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            this.Property(prop => prop.Season)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            this.Property(prop => prop.CountOrder)
                .IsRequired()
                .HasColumnType("int");

            this.Property(prop => prop.Photo)
                .HasColumnType("image");

            this.Property(prop => prop.DatePublication)
                .IsRequired()
                .HasColumnType("datetime");

            this.Property(prop => prop.Price)
                .IsRequired();

            this.ToTable("Product");
        }
    }

    // Настройки для UserGroup
    public class UserGroupConfiguration : EntityTypeConfiguration<DbUserGroup>
    {
        public UserGroupConfiguration()
        {
            this.HasKey(prop => prop.ID);
            this.Property(prop => prop.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.HasMany(ugroup => ugroup.Users)
                .WithRequired(ugroup => ugroup.UserGroup)
                .HasForeignKey(ugroup => ugroup.UserGroupID);

            this.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar");

            this.Property(prop => prop.Access).IsRequired();

            this.ToTable("UserGroup");
        }
    }

    // Настройки для User
    public class UserConfiguration : EntityTypeConfiguration<DbUser>
    {
        public UserConfiguration()
        {
            this.HasKey(prop => prop.ID);
            this.Property(prop => prop.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            this.Property(prop => prop.Name)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar");

            this.Property(prop => prop.Email)
                .IsRequired()
                .HasMaxLength(60)
                .HasColumnType("varchar");

            this.Property(prop => prop.Password)
                .IsRequired()
                .HasColumnType("varchar");

            this.ToTable("User");
        }
    }
}
