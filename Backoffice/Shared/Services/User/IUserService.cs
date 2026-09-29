using Framework.Shared.Models.User;
using Framework.Shared.Requests.User;

namespace Framework.Shared.Services.User
{
    public interface IUserService
    {
        Task Register(RegisterDto request);
        Task<UserModel?> GetByLoginOrEmail(string loginOrEmail);
        Task<UserModel?> GetById(int userId);
        Task Update(params object[] parameters);
        Task Delete(int userId);
        Task ChangeRole(string role);
        Task ChangePassword(ChangePasswordDto request);
        Task RemindPassword(string email);
        Task Block(int userId);
    }
}
