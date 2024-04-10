using KeyNerd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyNerd.Persistence.Mappings
{
    class KeycapMapping : IEntityTypeConfiguration<Keycap>
    {
        public void Configure(EntityTypeBuilder<Keycap> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(Keycap.NAME_MAX_LENGTH).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.CreatedBy).IsRequired();
            builder.HasMany(x => x.Details).WithOne(x => x.Keycap);
        }
    }
}
