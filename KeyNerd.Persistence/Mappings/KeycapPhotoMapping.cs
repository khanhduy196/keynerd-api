using KeyNerd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyNerd.Persistence.Mappings
{
    public class KeycapPhotoMapping : IEntityTypeConfiguration<KeycapPhoto>
    {
        public void Configure(EntityTypeBuilder<KeycapPhoto> builder)
        {
            builder.HasKey(x => new { x.KeycapId, x.Url });
            builder.Property(x => x.Url).IsRequired();
            builder.HasOne(x => x.Keycap).WithMany(x => x.Photos).HasForeignKey(x => x.KeycapId);
        }
    }
}
