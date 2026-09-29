using Discount.Api.ApiModels;
using Discount.Data.DataModels;

namespace Discount.Core.Services.Discount
{
    internal partial class DiscountService
    {
        public async Task Update(int discountId, UpdateDiscountRequest request)
        {
            DiscountModel model = await Get(discountId);

            model.Percentage = request.Percentage ?? model.Percentage;
            model.ValidTo = request.ValidTo ?? model.ValidTo;

            IEnumerable<ProductModel> products = await _productService.GetList();
            List<ProductModel> requestedProducts = GetRequestedProducts(products, request.Products).ToList();
            model.Products = requestedProducts.Any() ? requestedProducts : model.Products;

            await _discountDbContext.SaveChangesAsync();
        }

        private static IEnumerable<ProductModel> GetRequestedProducts(IEnumerable<ProductModel> products, List<int>? requestedProductsIds)
        {
            if (requestedProductsIds is not null)
                foreach (int id in requestedProductsIds)
                    yield return products.FirstOrDefault(p => p.ProductId == id) ?? throw new Exception("Product not found");
        }
    }
}
