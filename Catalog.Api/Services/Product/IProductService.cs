using Catalog.Api.ApiModels.Product.Request;
using Catalog.Api.DTO;
using Catalog.Api.Models;

namespace Catalog.Api.Services.Product
{
    public interface IProductService
    {
        Task<GetProductResponseDto> Get(int productId);
        Task<List<ProductModel>> Search(SearchProductRequestDto request);
        Task AddToBasket(int userId, int productId);
    }
}
