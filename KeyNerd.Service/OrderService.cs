using AutoMapper;
using KeyNerd.DataTransfer.Requests;
using KeyNerd.Domain.Entities;
using KeyNerd.Domain.Enums;
using KeyNerd.Infrastructure.Persistence;
using KeyNerd.Service.Contracts;
using KeyNerd.Service.Helpers;
using Microsoft.EntityFrameworkCore;

namespace KeyNerd.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Order> _repository;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Order> Create(CreateOrderRequest request)
        {
            var order = _mapper.Map<Order>(request);

            _repository.Add(order);

            await _unitOfWork.CommitAsync();

            return order;
        }

        public PaginatedList<Order> GetList(int itemsPerPage, int currentPage, string? searchQuery, OrderStatus? status)
        {
            var data = _repository.AsQueryable().Include(n => n.Details)
                .ThenInclude(n => n.KeycapDetail)
                .ThenInclude(n => n.Keycap)
                .ThenInclude(n => n.Photos).OrderByDescending(n => n.Id).AsQueryable();

            if (status.HasValue)
            {
                data = data.Where(n => n.OrderStatus == status.Value);
            }

            var list = new PaginatedList<Order>(itemsPerPage, currentPage, data);

            return list;
        }

        public async Task UpdateOrderStatus(UpdateOrderStatus request)
        {
            var order = await _repository.GetByIdAsync(request.Id);
            order.OrderStatus = request.Status;
            await _unitOfWork.CommitAsync();
        }
    }
}
