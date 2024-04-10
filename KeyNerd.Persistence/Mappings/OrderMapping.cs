using KeyNerd.Domain.Entities;
using KeyNerd.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KeyNerd.Persistence.Mappings
{
    class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.OrderStatus).IsRequired();
            builder.Property(x => x.OrderStatus).HasConversion(new EnumToStringConverter<OrderStatus>());

            // properties of auditable entity 
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.CreatedBy).IsRequired();
        }
    }
}
