using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Models.User
{
    [Owned]
    public class Password
    {
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
    }
}
