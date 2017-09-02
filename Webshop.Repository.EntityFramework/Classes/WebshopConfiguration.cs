using System.Data.Entity.ModelConfiguration;
using Webshop.Entities;

namespace Webshop.Repository.EntityFramework
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(g => g.Number)
                .IsRequired()
                .HasMaxLength(10);

            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(200);

            Property(g => g.CreationDate)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)
                .HasColumnType("datetime2");

            HasMany(e => e.OrderDetails).
            WithRequired(e => e.Product).
            WillCascadeOnDelete(false);
        }
    }

    public class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(200);

            Property(g => g.CreationDate)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)
                .HasColumnType("datetime2");

            HasMany(e => e.Products)
                .WithMany(e => e.ProductCategories)
                .Map(m => m.ToTable("ProductCategories_Products").MapLeftKey("ProductCategoryId").MapRightKey("ProductId"));
        }
    }

    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(g => g.LastName)
                .IsRequired()
                .HasMaxLength(50);

            Property(g => g.Email)
                .HasMaxLength(100);

            Property(g => g.CreationDate)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)
                .HasColumnType("datetime2");

            HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);
        }
    }

    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            Property(g => g.CreationDate)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)
                .HasColumnType("datetime2");

            HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);
        }
    }
}
