using KeyNerd.Domain.Enums;
using KeyNerd.Infrastructure.Persistence;

namespace KeyNerd.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public long Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string? Note { get; set; }
        public IList<OrderDetail> Details { get; set; }

    }
}
