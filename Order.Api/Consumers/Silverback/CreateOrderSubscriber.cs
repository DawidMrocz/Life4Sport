using Common.Silverback;

namespace Order.Api.Consumers.Silverback
{
    public class CreateOrderSubscriber
    {
        private readonly ILogger<CreateOrderSubscriber> _logger;

        public CreateOrderSubscriber(ILogger<CreateOrderSubscriber> logger)
        {
            _logger = logger;
        }

        //public void OnMessageReceived(SampleMessage message) =>
        public void OnMessageReceived(OrderItemCommand message) 
        {
            Console.WriteLine($"Aktywacja konsumera kafka w order");
            _logger.LogInformation("Received {MessageNumber}", message.ProductId);
        }
            
    }
}
