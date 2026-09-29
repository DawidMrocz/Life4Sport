using Framework.Shared.Controllers;
using Framework.Shared.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : IdentityController
    {
        public UserController(IServiceProvider serviceProvider, IUserService userService) : base(serviceProvider, userService) { }
    }
}
