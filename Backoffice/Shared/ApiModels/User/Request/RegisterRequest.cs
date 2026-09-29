using Framework.Shared.Attribiutes.Validation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Framework.Shared.ApiModels.User.Request
{
    public class RegisterRequest : IValidatableObject
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Incorrect email format")]
        public required string Email { get; set; }
        [StringLength(20, ErrorMessage = "Login to long")]
        public string? Login { get; set; }
        [RegularExpression("^[A-Z][a-z]*$")]
        [StringLength(20, ErrorMessage = "Incorrect first name format")]
        public string? FirstName { get; set; }
        [RegularExpression("^[A-Z][a-z]*$")]
        [StringLength(20, ErrorMessage = "Incorrect last name format")]
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        [PasswordValidation]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public string? Gender { get; set; }
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        //[DataType(DataType.Upload)]
        //[FileValidation(fileSize: 10, allowedExtensons: "jpg;png;jpeg")]
        public IFormFile? ProfilePhoto { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BirthDate > DateTime.Now)
            {
                yield return new ValidationResult(
                    $"Date of birth cannot be in future",
                    new[] { nameof(BirthDate) });
            }
        }
    }
}
