using Framework.Shared.Models;

namespace Framework.Shared.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseModel
    {
        Task<TEntity?> GetById(int id);
        Task<List<TEntity>> GetList();
        Task<int> Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
