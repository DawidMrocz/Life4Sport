using Catalog.Api.DTO.Category;

namespace Catalog.Api.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetList();
    }
}
