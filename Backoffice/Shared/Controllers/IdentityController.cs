using Framework.Shared.ApiModels.Access.Request;
using Framework.Shared.ApiModels.User.Request;
using Framework.Shared.CoreModels.Access;
using Framework.Shared.Extensions.Mappings.User;
using Framework.Shared.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace Framework.Shared.Controllers
{
    public abstract class IdentityController : AuthorizedController
    {
        protected readonly IUserService _userService;
        public IdentityController(IServiceProvider serviceProvider, IUserService userService) : base(serviceProvider)
        {
            _userService = userService;
        }

        /// <summary>
        /// Akcja do logowania
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="500">Error</response>
        /// <response code="400">Bad request</response>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                return Ok(await AuthenticationService.Login(new LoginDto(request.Email, request.Password, request.RememberMe)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Akcja do logowania
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="500">Error</response>
        /// <response code="400">Bad request</response>
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            AuthenticationService.Logout();
            return Ok("Pomyślnie wylogowano");
        }

        /// <summary>
        /// Akcja do otrzymania profilu
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="500">Error</response>
        /// <response code="400">Bad request</response>
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            if (AuthorizedUser is null) return Unauthorized("Authorization issue");
            return Ok(await _userService.GetById(AuthorizedUser.Id));
        }

        /// <summary>
        /// Akcja do przypomnienia hasła
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="500">Error</response>
        /// <response code="400">Bad request</response>
        [HttpPost("remind-password")]
        [AllowAnonymous]
        public IActionResult RemindPassword()
        {
            AuthenticationService.Logout();
            return Ok("Pomyślnie wylogowano");
        }

        /// <summary>
        /// Akcja do logowania
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="500">Error</response>
        /// <response code="400">Bad request</response>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            try
            {
                await _userService.Register(request.ToRegisterDto());
                return Ok("Pomyslna rejestracja");
            }
            catch (Exception ex)
            {
                // _logger.Log(GetType(), Level.Error, "Błąd servera", ex);
                return BadRequest(ex.Message);
            }
        }

        //[HttpDelete("delete")]
        //public async Task<IActionResult> Delete()
        //{
        //    return Ok(AuthorizedUser.Role);
        //}

        //[HttpPut("change-password")]
        //public async Task<IActionResult> ChangePassword()
        //{
        //    return Ok("Pomyslna rejestracja");
        //}

        //[HttpPut("change-role")]
        //public async Task<IActionResult> ChangeRole()
        //{
        //    return Ok("Pomyslna rejestracja");
        //}

        //[HttpPut("block")]
        //public async Task<IActionResult> Block()
        //{
        //    return Ok("Pomyslna rejestracja");
        //}
    }
}
