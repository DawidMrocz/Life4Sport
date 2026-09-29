using System.ComponentModel.DataAnnotations;

namespace Framework.Shared.ApiModels.Access.Request
{
    public sealed class LoginRequest
    {
        public LoginRequest(string email, string password, bool rememberMe)
        {
            Email = email;
            Password = password;
            RememberMe = rememberMe;
        }

        [Required]
        public string Email { get; set; }
        [Required]
        public  string Password { get; set; }
        public  bool RememberMe { get; set; } = false;
    }
}
