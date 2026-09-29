using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.Core.Services.BasketItem
{
    internal partial class BasketItemService
    {
        public async Task Delete(int basketItemId)
        {
            BasketItemModel model = await Get(basketItemId);

            _basketDbContext.Remove(model);

            await _basketDbContext.SaveChangesAsync();
        }
    }
}
