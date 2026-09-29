using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.Core.Services.BasketItem
{
    internal partial class BasketItemService
    {
        public async Task<BasketItemModel> Get(int basketItemId)
        {
            return await _basketDbContext.BasketItems.FirstOrDefaultAsync(i => i.BasketItemId == basketItemId)
                ?? throw new Exception("Item not found");
        }
    }
}
