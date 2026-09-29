using Identity.Api.Dto.Purchase;
using Identity.Api.Models;

namespace Identity.Api.Services.Purchase
{
    public interface IPurchaseService
    {
        Task<IEnumerable<PurchaseModel>> Search(PurchaseSearchRequest request);
        Task<PurchaseModel> Get(int purchaseId);
        Task Refund(int purchaseId, PurchaseRefundRequest request);
        Task Delete(int purchaseId);
    }
}
