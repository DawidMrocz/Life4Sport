using System.ComponentModel.DataAnnotations;

namespace Framework.Shared.CoreModels.Access
{
    public sealed class LoginDto
    {
        public string LoginOrEmail { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public LoginDto(string loginOrEmail, string password, bool rememberMe)
        {
            LoginOrEmail = loginOrEmail;
            Password = password;
            RememberMe = rememberMe;
        }
    }
}
