using Raport.Api.Data;
using Raport.Api.Models;

namespace Raport.Api.Services
{
    public class RaportService : IRaportService
    {
        private readonly RaportDbContext _raportDbContext;

        public RaportService(RaportDbContext raportDbContext)
        {
            _raportDbContext = raportDbContext;
        }

        public Task Create(object createRequest)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int raportId)
        {
            throw new NotImplementedException();
        }

        public Task<RaportModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RaportModel>> Search(object searchRequest)
        {
            throw new NotImplementedException();
        }

        public Task Update(object updateRequest, int raportId)
        {
            throw new NotImplementedException();
        }
    }
}
