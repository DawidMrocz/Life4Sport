using Discount.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Discount.Core.Services.Discount
{
    internal partial class DiscountService
    {
        public async Task<DiscountModel> Get(int discountId)
        {
            return await _discountDbContext.Discounts.FirstOrDefaultAsync(d => d.DiscountId == discountId)
                ?? throw new Exception("Discount not found");
        }

    }
}
