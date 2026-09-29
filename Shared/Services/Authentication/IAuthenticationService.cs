using Framework.Shared.ApiModels.Access.Request;
using Framework.Shared.DataModels.Authentication;

namespace Framework.Shared.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> Login(LoginRequest dto);
        void Logout();
        Task<AuthenticationUser?> GetAuthenticatedUser();
    }
}
