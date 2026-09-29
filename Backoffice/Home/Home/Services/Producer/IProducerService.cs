using Home.Dto.Producer;

namespace Home.Services.Producer
{
    public interface IProducerService
    {
        Task<GetProducerResponse> Get(int producerId);
        Task<IEnumerable<GetProducerResponse>> GetList();
        Task Create(CreateProducerRequest request);
        Task Update(int producerId, UpdateProducerRequest request);
        Task Delete(int producerId);
    }
}
