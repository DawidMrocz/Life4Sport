using Framework.Shared.Models.Token;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Shared.Models.User
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Index("IX_EmailLogin", 1, IsUnique = true)]
        public string Email { get; set; } = null!;
        [Index("IX_EmailLogin", 2, IsUnique = true)]
        public string? Login { get; set; }      
        public string Role { get; set; } = null!;
        public Password Password { get; set; } = null!;
        public Block Block { get; set; } = new();
        public Files Files { get; set; } = new();
        public Address? Address { get; set; }
        public List<TokenModel> Tokens { get; set; } = new();
    }
}
