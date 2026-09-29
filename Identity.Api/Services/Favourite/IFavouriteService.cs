namespace Identity.Api.Services.Favourite
{
    public interface IFavouriteService
    {
        Task Create(int productId);
        Task Delete(int productId);
    }
}
