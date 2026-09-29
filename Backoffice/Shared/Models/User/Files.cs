using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Models.User
{
    [Owned]
    public class Files
    {
        public int? Photo { get; set; }
        public List<int> Documents { get; set; } = new();
    }
}
