using Basket.Api.Data;
using Basket.Api.Services.BasketItem;
using Framework.Shared.Attribiutes.Dependency;

namespace Basket.Core.Services.BasketItem
{
    [DependencyInjection(typeof(IBasketItemService))]
    internal partial class BasketItemService : IBasketItemService
    {
        private readonly BasketDbContext _basketDbContext;

        public BasketItemService(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }
    }
}
