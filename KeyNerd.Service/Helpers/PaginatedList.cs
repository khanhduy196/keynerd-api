namespace KeyNerd.Service.Helpers
{
    public class PaginatedList<T>
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<T> Items { get; set; }

        public PaginatedList(int itemsPerPage, int currentPage, IQueryable<T> data)
        {
            TotalItems = data.Count();
            TotalPages = (TotalItems % itemsPerPage) == 0 ? TotalItems / itemsPerPage : (TotalItems / itemsPerPage) + 1;
            ItemsPerPage = itemsPerPage;
            CurrentPage = currentPage;
            Items = data.Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage);
        }
    }
}
