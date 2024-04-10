using KeyNerd.Domain.Enums;

namespace KeyNerd.DataTransfer.Requests
{
    public class GetPaginatedOrderListRequest : GetPaginatedListRequest
    {
        public OrderStatus? Status { get; set; } 
    }
}
