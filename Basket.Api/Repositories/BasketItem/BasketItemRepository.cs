using Basket.Api.Data;
using Basket.Api.Repositories.BasketItem;

namespace Basket.Data.Repositories.BasketItem
{
    internal partial class BasketItemRepository : IBasketItemRepository
    {
        private readonly BasketDbContext _basketDbContext;

        public BasketItemRepository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }
    }
}
