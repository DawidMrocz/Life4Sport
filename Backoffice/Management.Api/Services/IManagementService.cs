using Management.Api.Dto;
using Management.Api.Models;

namespace Management.Api.Services
{
    public interface IManagementService
    {
        Task Create(CreateManagementRequest request);
        Task Update(int managementId, UpdateManagementRequest request);
        Task Block(int managementId, DateTime date);
        Task Unblock(int managementId);
        Task<ManagementModel> Get(int managementId);
        Task<IEnumerable<ManagementModel>> Search(SearchManagementRequest request);
        Task Delete(int managementId);
    }
}
