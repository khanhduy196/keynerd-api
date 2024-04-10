namespace KeyNerd.DataTransfer.Responses
{
    public class GetPaginatedOrderDetailListResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long KeycapId { get; set; }
        public List<string> Photos { get; set; }
        public string Profile { get; set; }
        public float Size { get; set; }
        public int Quantity { get; set; }
    }
}
