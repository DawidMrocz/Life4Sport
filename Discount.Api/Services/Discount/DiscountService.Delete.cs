using Discount.Data.DataModels;

namespace Discount.Core.Services.Discount
{
    internal partial class DiscountService
    {
        public async Task Delete(int discountId)
        {
            DiscountModel model = await Get(discountId);
            _discountDbContext.Remove(model);
            await _discountDbContext.SaveChangesAsync();
        }
    }
}
