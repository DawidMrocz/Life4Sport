using Basket.Api.Models;
using Common.ApiClient;
using Microsoft.EntityFrameworkCore;

namespace Basket.Core.Services.Basket
{
    internal partial class BasketService
    {
        public async Task AddDiscount(int userId, string discountCode)
        {
            BasketUserModel basketUser = await _basketDbContext.BasketUser.FirstOrDefaultAsync(u => u.ExternalId == userId)
                ?? throw new Exception("User not found");

            bool alreadyUse = basketUser.Discounts.Any(d => d.Code == discountCode);

            if (alreadyUse) throw new Exception("Cannot add discount again"); // job do usuwania starych discountów

            //GetDiscountResponse discount = await _apiClient.GetAsync<GetDiscountResponse>("/discount")
            //    ?? throw new Exception("Discount not found");

            //List<ProductModel> products = await _basketDbContext.Products.Where(t => discount.Products.Contains(t.ProductId)).ToListAsync();

            //DiscountModel discountModel = new()
            //{
            //    ExternalId= discount.DiscountId,
            //    Code = discount.Code,
            //    Percentage = discount.Percentage,
            //    ValidTo = discount.ValidTo,
            //    Used = true,
            //    Products = products,
            //    BasketUserId = userId
            //};

            //basketUser.Discounts.Add(discountModel);
            //await _basketDbContext.SaveChangesAsync();
        }
    }
}
