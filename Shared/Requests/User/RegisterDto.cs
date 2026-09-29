using Microsoft.AspNetCore.Http;

namespace Framework.Shared.Requests.User
{
    public class RegisterDto
    {
        public string Password { get; set; }
        public IFormFile? ProfilePhoto { get; set; }
        public List<IFormFile> Files { get; set; } = new();

        public RegisterDto(
            string email,
            string? login,
            string? firstName,
            string? lastName,
            DateTime? birthDate,
            string password,
            string? gender,
            string? phone,
            IFormFile? profilePhoto)
        {
            Password  = password;

            ProfilePhoto  = profilePhoto;
        }
    }
}
