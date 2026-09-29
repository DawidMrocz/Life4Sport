using Framework.Shared.Enums;
using Framework.Shared.Models.Token;
using System.Text.Json.Serialization;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Framework.Shared.Models.User
{
    [Index(nameof(Email), IsUnique = true)]
    public abstract class UserBaseModel : BaseModel
    {
        public string Email { get; set; } = null!;
        public string Role { get; set; } = RoleEnum.User.ToString();
        [JsonIgnore]
        public byte[] PasswordHash { get; set; } = null!;
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; } = null!;
        public bool Blocked { get; set; } = false;
        public DateTime? UnblockTime { get; set; }
        public int? Photo { get; set; }
        public List<int> Documents { get; set; } = new();
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public List<TokenModel> Tokens { get; set; } = new();
    }
}
