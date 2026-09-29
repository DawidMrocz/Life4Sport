using Order.Api.Dto;
using Order.Api.Models;

namespace Order.Api.Services
{
    public interface IOrderService
    {
        Task Create(CreateOrderRequest request);
        Task Update(int orderId, UpdateOrderRequest request);
        Task<OrderModel> Get(int orderId);
        Task<IEnumerable<OrderModel>> Search(SearchOrderRequest request);
        Task Delete(int orderId);
    }
}
