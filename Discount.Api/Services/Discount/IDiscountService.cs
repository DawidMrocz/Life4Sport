using Discount.Api.ApiModels;
using Discount.Data.DataModels;

namespace Discount.Core.Services.Discount
{
    public interface IDiscountService
    {
        Task Create(CreateDiscountRequest request);
        Task Update(int discountId, UpdateDiscountRequest request);
        Task Delete(int discountId);
        Task<DiscountModel> Get(int discountId);
        Task<IEnumerable<DiscountModel>> Search(SearchDiscountRequest request);
    }
}
