using KeyNerd.Domain.Enums;

namespace KeyNerd.DataTransfer.Requests
{
    public class CreateOrderDetailRequest
    {
        public long KeycapDetailId { get; set; }
        public int Quantity { get; set; }
    }
}
