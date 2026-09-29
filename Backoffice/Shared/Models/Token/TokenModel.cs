using Framework.Shared.Models.User;

namespace Framework.Shared.Models.Token
{
    public class TokenModel
    {
        public int Id { get; set; }
        public string Value { get; set; } = null!;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ExpireDate { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; } = null!;
    }
}
