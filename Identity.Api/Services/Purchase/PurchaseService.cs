using Identity.Api.Dto.Purchase;
using Identity.Api.Models;

namespace Identity.Api.Services.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        public Task Delete(int purchaseId)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseModel> Get(int purchaseId)
        {
            throw new NotImplementedException();
        }

        public Task Refund(int purchaseId, PurchaseRefundRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PurchaseModel>> Search(PurchaseSearchRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
