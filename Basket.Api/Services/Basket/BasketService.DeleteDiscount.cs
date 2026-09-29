using Basket.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Basket.Core.Services.Basket
{
    internal partial class BasketService
    {
        public async Task DeleteDiscount(int discountId, int userId)
        {
            DiscountModel discount = await _basketDbContext.Discounts.FirstOrDefaultAsync(d => d.DiscountId == discountId && d.BasketUserId == userId)
                ?? throw new Exception("Discount not found");

            _basketDbContext.Discounts.Remove(discount);
            await _basketDbContext.SaveChangesAsync();
        }
    }
}
