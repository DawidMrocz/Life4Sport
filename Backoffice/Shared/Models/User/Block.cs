using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Models.User
{
    [Owned]
    public class Block
    {
        public bool Blocked { get; set; } = false;
        public DateTime? UnblockTime { get; set; }
    }
}
