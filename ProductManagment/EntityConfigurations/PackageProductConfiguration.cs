using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagment.Entities;

namespace ProductManagment.EntityConfigurations
{
    public class PackageProductConfiguration : IEntityTypeConfiguration<PackageProduct>
    {
        public void Configure(EntityTypeBuilder<PackageProduct> builder) 
        {
            builder.HasOne(P => P.Package)
                .WithMany(b => b.PackageProducts)
                .HasForeignKey(p => p.PackageId);
        }
    }
}
