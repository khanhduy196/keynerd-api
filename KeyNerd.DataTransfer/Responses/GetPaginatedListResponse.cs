namespace KeyNerd.DataTransfer.Responses
{
    public class GetPaginatedListResponse<T>
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
