using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Data;
using Framework.Shared.Models.Token;

namespace Framework.Shared.Services.Token
{
    [DependencyInjection(typeof(ITokenService))]
    internal class TokenService : ITokenService
    {
        private readonly FrameworkDbContext _frameworkDbContext;

        public TokenService(FrameworkDbContext frameworkDbContext)
        {
            _frameworkDbContext = frameworkDbContext;
        }

        public async Task CreateToken(TokenModel refreshToken)
        {
            await _frameworkDbContext.Tokens.AddAsync(refreshToken);
            await _frameworkDbContext.SaveChangesAsync();
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
