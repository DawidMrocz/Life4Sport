using Discount.Api.ApiModels;
using Discount.Data.DataModels;

namespace Discount.Core.Services.Discount
{
    internal partial class DiscountService
    {
        public async Task Create(CreateDiscountRequest request)
        {
            DiscountModel model = new()
            {
                Code = request.Code,
                Percentage = request.Percentage,
                ValidTo = request.ValidTo,
                Created = DateTime.Now,
                Products = request.Products.Select(p => new ProductModel()
                {
                    ExternalProductId = p
                }).ToList()
            };

            await _discountDbContext.Discounts.AddAsync(model);
            await _discountDbContext.SaveChangesAsync();
        }
    }
}
