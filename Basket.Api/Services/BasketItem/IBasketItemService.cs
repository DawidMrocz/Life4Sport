using Basket.Api.CoreModels;
using Basket.Api.Models;

namespace Basket.Api.Services.BasketItem
{
    public interface IBasketItemService
    {
        Task Delete(int basketItemId);
        Task Update(int basketItemId, int quantity, int userId);
        Task<BasketItemModel> Get(int basketItemId);
    }
}
