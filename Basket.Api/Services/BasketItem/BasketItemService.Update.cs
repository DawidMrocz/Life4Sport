using Basket.Api.Models;

namespace Basket.Core.Services.BasketItem
{
    internal partial class BasketItemService
    {
        public async Task Update(int basketItemId, int quantity,int userId)
        {
            BasketItemModel model = await Get(basketItemId);

            model.Quantity = quantity;

            _basketDbContext.SaveChanges();
        }
    }
}
