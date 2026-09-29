using Framework.Shared.Models.User;

namespace Framework.Shared.Repositories.User
{
    public interface IUserRepository<TModel> : IGenericRepository<TModel> 
        where TModel : UserBaseModel
    {
        Task<TModel?> GetByEmail(string email);
    }
}
