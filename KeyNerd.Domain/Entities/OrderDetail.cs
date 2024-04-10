using KeyNerd.Infrastructure.Persistence;

namespace KeyNerd.Domain.Entities
{
    public class OrderDetail : AuditableEntity
    {
        public string Id { get; set; }
        public long OrderId { get; set; }
        public long KeycapDetailId { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
        public KeycapDetail KeycapDetail { get; set; }
    }
}
