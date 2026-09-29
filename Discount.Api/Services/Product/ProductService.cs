using Discount.Api.Data;
using Discount.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Discount.Api.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly DiscountDbContext _discountDbContext;

        public ProductService(DiscountDbContext discountDbContext)
        {
            _discountDbContext = discountDbContext;
        }

        public async Task<IEnumerable<ProductModel>> GetList()
        {
            return await _discountDbContext.Products.ToListAsync();
        }
    }
}
