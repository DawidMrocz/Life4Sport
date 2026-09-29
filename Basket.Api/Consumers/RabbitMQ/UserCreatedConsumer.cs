using Basket.Api.Data;
using Basket.Api.Models;
using Common.MassTransit;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Basket.Api.Consumers.RabbitMQ
{
    public class UserCreatedConsumer : IConsumer<AddToBasketCommand>
    {
        private readonly BasketDbContext _basketDbContext;

        public UserCreatedConsumer(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }

        public async Task Consume(ConsumeContext<AddToBasketCommand> context)
        {
            Console.WriteLine("Wbiłem do konsumera");

            BasketModel? basket = await _basketDbContext.Baskets.FirstOrDefaultAsync(b => b.BasketUserId == context.Message.UserId);

            if (basket is null)
            {
                basket = new BasketModel()
                {
                    BasketUserId = context.Message.UserId,
                };
                await _basketDbContext.Baskets.AddAsync(basket);
            }


            Console.WriteLine("Konsumer add to basekt");

            BasketItemModel basketItem = new()
            {
                Quantity = context.Message.Quantity,
                BasketId = basket.BasketId,
                ProductId = context.Message.ProductId
            };

            await _basketDbContext.BasketItems.AddAsync(basketItem);
            await _basketDbContext.SaveChangesAsync();
        }
    }
}
