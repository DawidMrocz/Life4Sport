using Raport.Api.Models;

namespace Raport.Api.Services
{
    public interface IRaportService
    {
        Task<RaportModel> Get(int id);
        Task<IEnumerable<RaportModel>> Search(object searchRequest);
        Task Create(object createRequest);
        Task Update(object updateRequest, int raportId);
        Task Delete(int raportId);
    }
}
