using Catalog.Api.DTO.Producer;

namespace Catalog.Api.Services.Producer
{
    public interface IProducerService
    {
        Task<IEnumerable<ProducerResponse>> GetList();
    }
}
