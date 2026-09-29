using Management.Api.Data;
using Management.Api.Dto;
using Management.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Management.Api.Services
{
    public class ManagementService : IManagementService
    {
        private readonly ManagementDbContext _managementDbContext;

        public ManagementService(ManagementDbContext managementDbContext)
        {
            _managementDbContext = managementDbContext;
        }

        public async Task Delete(int managementId)
        {
            ManagementModel model = await Get(managementId);
            _managementDbContext.Remove(model);
            await _managementDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ManagementModel>> Search(SearchManagementRequest request)
        {
            return await _managementDbContext.Managements.ToListAsync();
        }

        //public async Task Update(int managementId, UpdateManagementRequest request)
        //{
        //    ManagementModel model = await Get(managementId);

        //    //model.Name = request.Name ?? model.Name;
        //    //model.Description = request.Description ?? model.Description;
        //    //model.Quantity = request.Quantity ?? model.Quantity;
        //    //model.Price = request.Price ?? model.Price;
        //    //model.Season = request.Season ?? model.Season;

        //    await _managementDbContext.SaveChangesAsync();
        //}

        public async Task<ManagementModel> Get(int managementId)
        {
            return await _managementDbContext.Managements.FirstOrDefaultAsync(p => p.ManagementId == managementId)
                ?? throw new Exception("Management not found");
        }

        public Task Create(CreateManagementRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Update(int managementId, UpdateManagementRequest request)
        {
            throw new NotImplementedException();
        }

        public Task Block(int managementId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task Unblock(int managementId)
        {
            throw new NotImplementedException();
        }
    }
}
