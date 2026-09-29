using System.ComponentModel.DataAnnotations;

namespace Framework.Shared.ApiModels.Access.Request
{
    public sealed class LoginRequest
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public required bool RememberMe { get; set; } = false;
    }
}
