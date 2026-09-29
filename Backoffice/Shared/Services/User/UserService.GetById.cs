using Framework.Shared.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Identity.Services.User
{
    internal partial class UserService
    {
        public async Task<UserModel?> GetById(int userId)
        {
            return await _identityDbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}
