using KeyNerd.DataTransfer.Requests;
using KeyNerd.Domain.Entities;
using KeyNerd.Domain.Enums;
using KeyNerd.Service.Helpers;

namespace KeyNerd.Service.Contracts
{
    public interface IOrderService
    {
        Task<Order> Create(CreateOrderRequest request);
        PaginatedList<Order> GetList(int itemsPerPage, int currentPage, string? searchQuery, OrderStatus? status);
        Task UpdateOrderStatus(UpdateOrderStatus request);
    }
}
