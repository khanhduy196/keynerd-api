using KeyNerd.Domain.Entities;

namespace KeyNerd.Service.Contracts
{
    public interface ICategoryService
    {
        Task Create(Category category);
    }
}
