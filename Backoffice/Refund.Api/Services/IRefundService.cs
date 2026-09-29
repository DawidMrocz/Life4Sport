using Refund.Api.Dto.Refund;
using Refund.Api.Models.Refund;

namespace Refund.Api.Services
{
    public interface IRefundService
    {
        Task Create(CreateRefundRequest request);
        Task Update(int refundId, UpdateRefundRequest request);
        Task<RefundModel> Get(int refundId);
        Task<IEnumerable<RefundModel>> Search(SearchRefundRequest request);
        Task Delete(int refundId);
    }
}
