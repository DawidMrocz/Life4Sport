using Framework.Shared.CoreModels.Access;
using Framework.Shared.DataModels.Authentication;

namespace Framework.Shared.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> Login(LoginDto dto);
        void Logout();
        Task<AuthenticationUser?> GetAuthenticatedUser();
    }
}
