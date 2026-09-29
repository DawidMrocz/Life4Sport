using Whislist.Api.Models;

namespace Identity.Api.Services.Whislist
{
    public interface IWishlistService
    {
        Task Add(int productId, int userId);
        Task Remove(int wishItemId, int userId);
        Task<WishModel> GetList(int userId);
    }
}
