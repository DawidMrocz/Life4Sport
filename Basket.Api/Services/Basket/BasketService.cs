using Basket.Api.Data;
using Basket.Api.Services.Basket;
using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Client;
using MassTransit;
using Silverback.Messaging.Publishing;

namespace Basket.Core.Services.Basket
{
    [DependencyInjection(typeof(IBasketService))]
    internal partial class BasketService : IBasketService
    {
        private readonly BasketDbContext _basketDbContext;
        //private readonly ApiClient _apiClient;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IEventPublisher _eventPublisher;
        public BasketService(BasketDbContext basketDbContext, IConfiguration configuration, IPublishEndpoint publishEndpoint, IEventPublisher eventPublisher)
        {
            _basketDbContext = basketDbContext;
            //_apiClient = new ApiClient(configuration["ConnectionStrings:DiscountApiUrl"] ?? throw new Exception("Discount api url not found")); ;
            _publishEndpoint = publishEndpoint;
            _eventPublisher = eventPublisher;
        }
    }
}
