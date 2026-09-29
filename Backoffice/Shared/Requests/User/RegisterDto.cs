using Microsoft.AspNetCore.Http;

namespace Framework.Shared.Requests.User
{
    public class RegisterDto
    {
        public string Email { get; set; }
        public string? Login { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Password { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
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
            Email  = email;
            Login  = login;
            FirstName  = firstName;
            LastName  = lastName;
            BirthDate  = birthDate;
            Password  = password;
            Gender  = gender;
            Phone  = phone;
            ProfilePhoto  = profilePhoto;
        }
    }
}
