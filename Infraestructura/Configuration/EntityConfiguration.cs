using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.Core.Objects.DataClasses;

namespace Infrastructure.Configuration;

public class EntityConfiguration : IEntityTypeConfiguration<Entity>
{
    public void Configure(EntityTypeBuilder<Entity> entity)
    {
        entity.HasKey(x => x.EntityId);

        entity
            .Property(x => x.Name)
            .IsRequired();
        entity
            .Property(x => x.Description)
            .IsRequired();

        entity
            .HasOne(x => x.Customer)
            .WithMany(x => x.Entities)
            .HasForeignKey(x => x.CustomerId);
    }
}
