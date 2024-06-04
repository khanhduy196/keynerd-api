using KeyNerd.DataTransfer.Requests;
using KeyNerd.Domain.Entities;
using KeyNerd.Service.Helpers;


namespace KeyNerd.Service.Contracts
{
    public interface IKeycapService
    {
        Task<Keycap> Create(CreateKeycapRequest request);
        Task Update(UpdateKeycapRequest updated);
        Task Delete(long id);
        Task<Keycap> GetById(long id);
        PaginatedList<Keycap> GetList(int itemsPerPage, int currentPage, string? searchQuery);
        Task<List<KeycapDetail>> GetUsedDetailsOfKeycap(long id);

    }
}
