using Catalog.Api.Data;
using Catalog.Api.DTO.Producer;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Api.Services.Producer
{
    public class ProducerService : IProducerService
    {
        private readonly CatalogContext _catalogContext;

        public ProducerService(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<IEnumerable<ProducerResponse>> GetList()
        {
            return await _catalogContext.Producers.ToListAsync();
        }
    }
}
