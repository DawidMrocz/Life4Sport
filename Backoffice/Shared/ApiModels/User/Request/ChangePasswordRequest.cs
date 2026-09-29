using Framework.Shared.Attribiutes.Validation;
using System.ComponentModel.DataAnnotations;

namespace Framework.Shared.ApiModels.User.Request
{
    public class ChangePasswordRequest : IValidatableObject
    {
        [PasswordValidation]
        public required string NewPassword { get; set; }
        public required string RepeatPassword { get; set; }
        public required string OldPassword { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!NewPassword.Equals(RepeatPassword))
            {
                yield return new ValidationResult(
                    $"Passwords are not the same",
                    new[] { nameof(RepeatPassword) });
            }
        }
    }
}
