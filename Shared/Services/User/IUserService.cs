using Framework.Shared.Models.User;
using Framework.Shared.Requests.User;

namespace Framework.Shared.Services.User
{
    public interface IUserRepository<TModel> where TModel : UserBaseModel
    {
        //Task<TModel> Register(TModel model);
        //Task<TModel?> GetByEmail(string email);
        //Task<TModel?> GetById(int id);
        //Task<TModel?> GetByIdForAuth(int id);
        //Task<TModel?> GetUserForAuth(string email);
        //Task Update(TModel model);
        //Task Delete(TModel model);
        //Task ChangeRole(string role);
        //Task ChangePassword(ChangePasswordDto request);
        //Task RemindPassword(string email);
        //Task Block(int id);
    }
}
