using Discount.Data.DataModels;

namespace Discount.Api.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetList();
    }
}
