

namespace KeyNerd.DataTransfer.Responses
{
    public class GetPaginatedOrderListResponse
    {
        public long Id { get; set; }
        public string Note { get; set; }
        public string OrderStatus { get; set; }
        public List<GetPaginatedOrderDetailListResponse> Details { get; set; }
    }
}
