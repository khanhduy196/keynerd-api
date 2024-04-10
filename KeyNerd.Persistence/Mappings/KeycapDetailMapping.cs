using KeyNerd.Domain.Entities;
using KeyNerd.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KeyNerd.Persistence.Mappings
{
    class KeycapDetailMapping : IEntityTypeConfiguration<KeycapDetail>
    {
        public void Configure(EntityTypeBuilder<KeycapDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Profile).IsRequired();
            builder.Property(x => x.Profile).HasConversion(new EnumToStringConverter<KeycapProfile>());
            builder.Property(x => x.Size).IsRequired();

            builder.HasOne(x => x.Keycap).WithMany(x => x.Details).HasForeignKey(x => x.KeycapId);
        }
    }
}
