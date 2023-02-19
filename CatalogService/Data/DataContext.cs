using CatalogService.Data.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
namespace CatalogService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            :base(options)
        { 
        }

        public DbSet<Category> Categories =>  Set<Category>();
        public DbSet<SubCategory> SubCategories => Set<SubCategory>();
        public DbSet<Product> Products => Set<Product>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
              .HasKey(category => new { category.Id });
        }
    }
}
