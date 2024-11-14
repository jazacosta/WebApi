using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.HasKey(x => x.PaymentId);

            entity
            .Property(x => x.Amount)
            .IsRequired();
            entity
            .Property(x => x.AvailableCredit)
            .IsRequired();
            entity
            .Property(x => x.PaymentMethod)
            .IsRequired();
            entity
            .Property(x => x.Date)
            .IsRequired();

            entity
                .HasOne(x => x.Card)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.CardId);
        }
    }
}