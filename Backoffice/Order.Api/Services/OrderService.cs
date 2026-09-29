using Framework.Shared.Attribiutes.Dependency;
using Microsoft.EntityFrameworkCore;
using Order.Api.Data;
using Order.Api.Dto;
using Order.Api.Models;

namespace Order.Api.Services.Order
{
    [DependencyInjection(typeof(IOrderService))]
    public partial class OrderService : IOrderService
    {
        private readonly OrderDbContext _orderDbContext;

        public async Task Create(CreateOrderRequest request)
        {
            OrderModel model = new()
            {
                //Name = request.Name,
                //Description = request.Description,
                //Quantity = request.Quantity,
                //Price = request.Price,
                //Season = request.Season
            };

            await _orderDbContext.Orders.AddAsync(model);
            await _orderDbContext.SaveChangesAsync();
        }

        public async Task Delete(int orderId)
        {
            OrderModel model = await Get(orderId);
            _orderDbContext.Remove(model);
            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderModel>> Search(SearchOrderRequest request)
        {
            return await _orderDbContext.Orders.ToListAsync();
        }

        public async Task Update(int orderId, UpdateOrderRequest request)
        {
            OrderModel model = await Get(orderId);

            //model.Name = request.Name ?? model.Name;
            //model.Description = request.Description ?? model.Description;
            //model.Quantity = request.Quantity ?? model.Quantity;
            //model.Price = request.Price ?? model.Price;
            //model.Season = request.Season ?? model.Season;

            await _orderDbContext.SaveChangesAsync();
        }

        public async Task<OrderModel> Get(int orderId)
        {
            return await _orderDbContext.Orders.FirstOrDefaultAsync(p => p.OrderId == orderId)
                ?? throw new Exception("Order not found");
        }
    }
}
