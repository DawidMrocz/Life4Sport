using Basket.Api.CoreModels;

namespace Basket.Api.Services.Basket
{
    public interface IBasketService
    {
        Task AddDiscount(int userId, string discountCode);
        Task DeleteDiscount(int discountId, int userId);
        Task<GetBasketDto> Get(int userId);
        Task CreateOrder(int userId);
    }
}
