using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.HasKey(x => x.ProductId);

        entity
            .Property(x => x.Name)
            .IsRequired();
        entity
            .Property(x => x.Description)
            .IsRequired();
        entity
            .Property(x => x.Status)
            .IsRequired();
        entity
            .Property(x => x.Date)
            .IsRequired();

        entity
            .HasOne(x => x.Entity)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.EntityId);
    }
}
