namespace KeyNerd.DataTransfer.Requests
{
    public class GetPaginatedListRequest
    {
        public const int ITEMS_PER_PAGE_DEFAULT = 15;

        public int ItemsPerPage { get; set; } = ITEMS_PER_PAGE_DEFAULT;
        public int CurrentPage { get; set; } = 1;
        public string? SearchQuery { get; set; }

    }
}
