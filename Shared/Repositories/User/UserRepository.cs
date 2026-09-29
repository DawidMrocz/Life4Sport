using Framework.Shared.Models.File;
using Framework.Shared.Models.Token;
using Framework.Shared.Models.User;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Repositories.User
{
    public interface IUserServiceModels
    {
        public DbSet<TokenModel> Tokens { get; set; }
        public DbSet<FileModel> Files { get; set; }
    }

    internal partial class UserRepository<TDbContext, TModel> : GenericRepository<TDbContext, TModel>, IUserRepository<TModel>
        where TDbContext : DbContext, IUserServiceModels
        where TModel : UserBaseModel
    {
        public UserRepository(TDbContext dbContext) : base(dbContext) { }

        public async Task<TModel?> GetByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
