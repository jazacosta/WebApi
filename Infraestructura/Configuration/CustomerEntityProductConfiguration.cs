using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CustomerEntityProductConfiguration : IEntityTypeConfiguration<CustomerEntityProduct>
    {
        public void Configure(EntityTypeBuilder<CustomerEntityProduct> entity)
        {
            entity.HasKey(x => x.CustomerEntityProductId);

            entity.HasOne(x => x.CustomerEntity)
                  .WithMany(x => x.CustomerEntityProducts)
                  .HasForeignKey(x => x.CustomerEntityId);

            entity.HasOne(x => x.Products)
                  .WithMany(x => x.CustomerEntityProducts)
                  .HasForeignKey(x => x.ProductId);
        }
    }
}
