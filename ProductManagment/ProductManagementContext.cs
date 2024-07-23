using Microsoft.EntityFrameworkCore;
using ProductManagment.Entities;
using ProductManagment.EntityConfigurations;


namespace ProductManagment
{
    public class ProductManagementContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<PackageProduct> PackageProducts { get; set; }

        public ProductManagementContext()
        {

        }

        public ProductManagementContext(DbContextOptions options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new PackageProductConfiguration());
           
        }
    }
}
