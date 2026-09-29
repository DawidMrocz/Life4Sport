using Framework.Shared.Attribiutes.Dependency;
using Identity.Api.Data;
using Whislist.Api.Models;

namespace Identity.Api.Services.Whislist
{
    [DependencyInjection(typeof(IWishlistService))]
    public partial class WishlistService : IWishlistService
    {
        private readonly IdentityDbContext _identityDbContext;

        public WishlistService(IdentityDbContext identityDbContext)
        {
            _identityDbContext = identityDbContext;
        }

        public Task Add(int productId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<WishModel> GetList(int userId)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int wishItemId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
