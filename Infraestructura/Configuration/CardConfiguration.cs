using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> entity)
    {
        entity.HasKey(x => x.CardId);

        entity
            .Property(x => x.Number)
            .IsRequired();

        entity
            .HasOne(x => x.Customer)
            .WithMany(x => x.Cards)
            .HasForeignKey(x => x.CustomerId);
    }
}
