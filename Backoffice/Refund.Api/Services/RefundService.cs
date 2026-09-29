using Microsoft.EntityFrameworkCore;
using Refund.Api.Data;
using Refund.Api.Dto.Refund;
using Refund.Api.Models.Refund;

namespace Refund.Api.Services
{
    public class RefundService : IRefundService
    {
        private readonly RefundDbContext _refundDbContext;

        public RefundService(RefundDbContext refundDbContext)
        {
            _refundDbContext = refundDbContext;
        }

        public async Task Create(CreateRefundRequest request)
        {
            RefundModel model = new()
            {
                //Name = request.Name,
                //Description = request.Description,
                //Quantity = request.Quantity,
                //Price = request.Price,
                //Season = request.Season
            };

            await _refundDbContext.Refunds.AddAsync(model);
            await _refundDbContext.SaveChangesAsync();
        }

        public async Task Delete(int refundId)
        {
            RefundModel model = await Get(refundId);
            _refundDbContext.Remove(model);
            await _refundDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RefundModel>> Search(SearchRefundRequest request)
        {
            return await _refundDbContext.Refunds.ToListAsync();
        }

        public async Task Update(int refundId, UpdateRefundRequest request)
        {
            RefundModel model = await Get(refundId);

            //model.Name = request.Name ?? model.Name;
            //model.Description = request.Description ?? model.Description;
            //model.Quantity = request.Quantity ?? model.Quantity;
            //model.Price = request.Price ?? model.Price;
            //model.Season = request.Season ?? model.Season;

            await _refundDbContext.SaveChangesAsync();
        }

        public async Task<RefundModel> Get(int refundId)
        {
            return await _refundDbContext.Refunds.FirstOrDefaultAsync(p => p.RefundId == refundId)
                ?? throw new Exception("Refund not found");
        }
    }
}
