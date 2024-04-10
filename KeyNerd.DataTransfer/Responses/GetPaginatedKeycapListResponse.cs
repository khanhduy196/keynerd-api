namespace KeyNerd.DataTransfer.Responses
{
    public class GetPaginatedKeycapListResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<GetPaginatedKeycapDetailListResponse> Details { get; set; }
    }
}
