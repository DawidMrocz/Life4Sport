using Framework.Shared.Configuration;
using Framework.Shared.DataModels.Authentication;
using Framework.Shared.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Framework.Shared.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class AuthorizedController(IServiceProvider serviceProvider) : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        protected AuthenticationUser? AuthorizedUser => AuthenticationService.GetAuthenticatedUser().Result;
        protected IAuthenticationService AuthenticationService => _serviceProvider
                .GetRequiredKeyedService<IAuthenticationService>(FrameworkConfiguration.AuthorizationProvider)
                    ?? throw new Exception("Authorization provider not found");
    }
}
