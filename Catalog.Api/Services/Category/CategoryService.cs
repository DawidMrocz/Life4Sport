using Catalog.Api.Data;
using Catalog.Api.DTO.Category;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly CatalogContext _catalogContext;

        public CategoryService(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<IEnumerable<CategoryResponse>> GetList()
        {
            return await _catalogContext.Categories.ToListAsync();
        }
    }
}
