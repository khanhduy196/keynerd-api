namespace KeyNerd.DataTransfer.Requests
{
    public class CreateOrderRequest
    {
        public string Note { get; set; }
        public List<CreateOrderDetailRequest> Details { get; set; }
    }
}
