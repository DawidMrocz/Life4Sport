using Home.Dto.Category;

namespace Home.Services.Category
{
    public interface ICategoryService
    {
        Task<GetCategoryResponse> Get(int categoryId);
        Task<IEnumerable<GetCategoryResponse>> GetList();
        Task Create(CreateCategoryRequest request);
        Task Update(int categoryId, UpdateCategoryRequest request);
        Task Delete(int categoryId);
    }
}
