using KeyNerd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyNerd.Persistence.Mappings
{
    class OrderDetailMapping : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValue("NEWID()");
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(x => x.Order).WithMany(x => x.Details);
            builder.HasOne(x => x.KeycapDetail).WithMany(x => x.OrderDetails);

            // properties of auditable entity 
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.CreatedBy).IsRequired();
        }
    }
}
