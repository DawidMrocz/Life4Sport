using Basket.Api.CoreModels;
using Basket.Api.Models;
using Basket.Api.Services.Basket;
using Common.Silverback;
using Microsoft.EntityFrameworkCore;

namespace Basket.Core.Services.Basket
{
    internal partial class BasketService
    {
        public async Task<GetBasketDto> Get(int userId)
        {
            await _eventPublisher.PublishAsync(new OrderItemCommand()
            {
                Quantity = 34,
                Price = 34,
                ProductId = 34
            });

            BasketModel? model = await _basketDbContext.Baskets.FirstOrDefaultAsync(b => b.BasketUserId == userId);

            if (model is null)
            {
                BasketUserModel user = await _basketDbContext.BasketUser.FirstOrDefaultAsync(u => u.ExternalId == userId)
                    ?? throw new Exception("User not found");


                BasketModel newBasket = new()
                {
                    BasketUserId = user.BasketUserId
                };

                await _basketDbContext.Baskets.AddAsync(newBasket);

                model = newBasket;
            }

            return new GetBasketDto();
        }
    }
}
