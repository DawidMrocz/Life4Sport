using Discount.Api.ApiModels;
using Discount.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Discount.Core.Services.Discount
{
    internal partial class DiscountService
    {
        public async Task<IEnumerable<DiscountModel>> Search(SearchDiscountRequest request)
        {
            return await _discountDbContext.Discounts.ToListAsync();
        }
    }
}
