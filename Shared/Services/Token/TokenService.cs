using Framework.Identity.Services.User;
using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Models.Token;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Services.Token
{
    [DependencyInjection(typeof(ITokenService))]
    internal class TokenService<TDbContext> : ITokenService
        where TDbContext : DbContext, IUserServiceModels
    {
        private readonly TDbContext _dbContext;
        private readonly DbSet<TokenModel> _dbSet;

        public TokenService(TDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TokenModel>();
        }

        public async Task CreateToken(TokenModel refreshToken)
        {
            await _dbSet.AddAsync(refreshToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteToken(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenModel> GetTokenByValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}
