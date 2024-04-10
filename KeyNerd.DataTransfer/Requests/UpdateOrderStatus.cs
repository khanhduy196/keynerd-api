using KeyNerd.Domain.Enums;

namespace KeyNerd.DataTransfer.Requests
{
    public class UpdateOrderStatus
    {
        public long Id { get;set; }
        public OrderStatus Status { get; set; }
    }
}
