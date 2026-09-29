using Framework.Shared.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Shared.Services.Token
{
    public interface ITokenService
    {
        Task<TokenModel> GetTokenByValue(string value);
        Task DeleteToken(int id);
        Task CreateToken(TokenModel refreshToken);
    }
}
