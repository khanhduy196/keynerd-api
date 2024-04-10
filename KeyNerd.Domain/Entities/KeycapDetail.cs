using KeyNerd.Domain.Enums;
using KeyNerd.Infrastructure.Persistence;

namespace KeyNerd.Domain.Entities
{
    public class KeycapDetail
    {
        public long Id { get; set; }
        public long KeycapId { get; set; }
        public KeycapProfile Profile { get; set; }
        public float Size { get; set; }
        public Keycap Keycap { get; set; }
        public string? FileUrl { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; }

    }
}
