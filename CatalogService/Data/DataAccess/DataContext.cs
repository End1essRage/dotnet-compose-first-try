using CatalogService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace CatalogService.Data.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<SubCategory> SubCategories => Set<SubCategory>();
        public DbSet<Product> Products => Set<Product>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
              .HasKey(category => new { category.Id });

            builder.Entity<SubCategory>()
              .HasKey(subCategory => new { subCategory.Id });

            builder.Entity<Product>()
              .HasKey(product => new { product.Id });
        }
    }
}
