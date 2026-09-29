using Framework.Shared.Configuration;
using Framework.Shared.CoreModels.Access;
using Framework.Shared.DataModels.Authentication;
using Framework.Shared.Models.User;
using Framework.Shared.Services.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Data;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Framework.Shared.Services.Authentication
{
    public class AuthenticationService_Cookie : IAuthenticationService
    {
        public readonly IConfiguration _configuration;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected const string LoggedUserKey = "UserSessionKey";
        private readonly IUserService _userService;
        public AuthenticationService_Cookie(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IUserService userService)
        {

            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _userService = userService;
        }

        public async Task<string> Login(LoginDto dto)
        {
            UserModel? user = await _userService.GetByLoginOrEmail(dto.LoginOrEmail)
                ?? throw new Exception("Nie znaleziono użytkownika lub nie poprawne hasło");

            if (user.Block.Blocked) throw new Exception("Konoto zostało zablokowane");

            if (!VerifyPasswordHash(dto.Password, user.Password.PasswordHash, user.Password.PasswordSalt))
                throw new Exception("Nie poprawne hasło");

            string authToken = Guid.NewGuid().ToString();

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("CSRFProtection", authToken.ToString()),
            };

            ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new(identity);
            AuthenticationProperties authenticationProperties = new()
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.AddMinutes(FrameworkConfiguration.SessionTimeout),
                IsPersistent = dto.RememberMe
            };

            await _httpContextAccessor.HttpContext!.SignInAsync(
                scheme: CookieAuthenticationDefaults.AuthenticationScheme,
                principal: principal,
                properties: authenticationProperties
            );

            _httpContextAccessor.HttpContext!.User = principal;

            AuthenticationUser authenticationUser = new()
            {
                Id = user.UserId,
                AuthorizeToken = authToken ?? Guid.NewGuid().ToString(),
                Role = user.Role
            };

            _httpContextAccessor.HttpContext.Session.SetString(LoggedUserKey, JsonConvert.SerializeObject(authenticationUser));

            return "Pomyślnie zalogowano";
        }
        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new(passwordSalt))
            {
                byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public void Logout()
        {
            _httpContextAccessor.HttpContext?.Session.Remove(LoggedUserKey);
            _httpContextAccessor.HttpContext?.SignOutAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public virtual async Task<AuthenticationUser?> GetAuthenticatedUser()
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext!;
            IIdentity? userIdentity = httpContext.User.Identity;

            if (userIdentity is null || !userIdentity.IsAuthenticated) return default;
            if (userIdentity is WindowsIdentity) return default;
            if (userIdentity is not ClaimsIdentity) return default;

            string? userIdentifier = ((ClaimsIdentity)userIdentity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            string? CSRFProtectionToken = ((ClaimsIdentity)userIdentity).Claims.FirstOrDefault(x => x.Type == "CSRFProtection")?.Value;

            AuthenticationUser? userFromSession;

            if (httpContext.Session.Keys.Contains(LoggedUserKey))
            {
                string? value = _httpContextAccessor.HttpContext?.Session.GetString(LoggedUserKey);
                JsonSerializerSettings settings = new();
                settings.ObjectCreationHandling = ObjectCreationHandling.Replace;
                userFromSession = value is null ? default : JsonConvert.DeserializeObject<AuthenticationUser>(value, settings);
            }
            else
            {
                userFromSession = default;
            }

            bool isAuthenticated = _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

            if (userFromSession != null && isAuthenticated && int.Parse(userIdentifier!) == userFromSession.Id)
                return userFromSession;

            if (string.IsNullOrEmpty(userIdentifier)) return default;

            UserModel user = await _userService.GetById(int.Parse(userIdentifier))
                ?? throw new Exception("User not found");

            AuthenticationUser authenticationUser = new()
            {
                Id = user.UserId,
                AuthorizeToken = CSRFProtectionToken ?? Guid.NewGuid().ToString(),
                Role = user.Role
            };
            httpContext.Session.SetString(LoggedUserKey, JsonConvert.SerializeObject(authenticationUser));
            return authenticationUser;

        }

        public async Task RefreshSession()
        {
            AuthenticationUser? authenticatedUser = await GetAuthenticatedUser();
            if (authenticatedUser is not null)
            {
                UserModel user = await _userService.GetById(authenticatedUser.Id)
                ?? throw new Exception("User not found");

                AuthenticationUser authenticationUser = new()
                {
                    Id = user.UserId,
                    AuthorizeToken = authenticatedUser.AuthorizeToken ?? Guid.NewGuid().ToString(),
                    Role = user.Role
                };
                _httpContextAccessor.HttpContext?.Session.SetString(LoggedUserKey, JsonConvert.SerializeObject(authenticationUser));
            }
        }
    }
}
