using Home.Dto.Product;
using Home.Models.Product;

namespace Home.Services.Product
{
    public interface IProductService
    {
        Task Create(CreateProductRequest request);
        Task Update(int productId, UpdateProductRequest request);
        Task Delete(int productId);
        Task<ProductModel> Get(int productId);
        Task<List<ProductModel>> Search(SearchProductRequestDto request);
    }
}
