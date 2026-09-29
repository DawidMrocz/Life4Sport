using Basket.Api.Models;
using Common.MassTransit;
using Common.Silverback;
using Microsoft.EntityFrameworkCore;

namespace Basket.Core.Services.Basket
{
    internal partial class BasketService
    {
        public async Task CreateOrder(int userId)
        {
            BasketModel basket = await _basketDbContext.Baskets.FirstOrDefaultAsync(b => b.BasketUserId == userId)
                ?? throw new Exception("Basket not found");

            CreateOrderCommand command = new()
            {
                UserId = userId,
                OrderItems = basket.BasketItems.Where(i => i.BasketId == basket.BasketId).Select(i => new OrderItemCommand()
                {
                    Quantity = i.Quantity,
                    Price = i.Price,
                    ProductId = i.ProductId,
                }).ToList(),
                Price = basket.TotalPrice
            };

            await _basketDbContext.Discounts
                .Where(i => i.BasketUserId == userId)
                .ExecuteUpdateAsync(d => d.SetProperty(
                    d => d.Used, true
                ));

            await _basketDbContext.BasketItems.Where(i => i.BasketId == basket.BasketId).ExecuteDeleteAsync();

            await _basketDbContext.SaveChangesAsync();

            await _eventPublisher.PublishAsync(new OrderItemCommand()
            {
                Quantity = 34,
                Price = 34,
                ProductId = 34
            });
        }
    }
}
