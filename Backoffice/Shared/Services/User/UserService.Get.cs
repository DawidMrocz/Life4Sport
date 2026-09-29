using Framework.Shared.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Framework.Identity.Services.User
{
    internal partial class UserService
    {
        public async Task<UserModel?> GetByLoginOrEmail(string loginOrEmail)
        {
            return await _identityDbContext.Users.Where(u => u.Email == loginOrEmail ||  u.Login == loginOrEmail).FirstOrDefaultAsync();
        }
    }
}
