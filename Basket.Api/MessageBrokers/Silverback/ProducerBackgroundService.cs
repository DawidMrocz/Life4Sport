using Common.Silverback;
using Silverback.Messaging.Broker;
using Silverback.Messaging.Publishing;

namespace Basket.Api.MessageBrokers.Silverback
{
    public class ProducerBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        private readonly ILogger<ProducerBackgroundService> _logger;

        public ProducerBackgroundService(
            IServiceScopeFactory serviceScopeFactory,
            ILogger<ProducerBackgroundService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Create a service scope and resolve the IPublisher
            // (the IPublisher cannot be resolved from the root scope and cannot
            // therefore be directly injected into the BackgroundService)
            using var scope = _serviceScopeFactory.CreateScope();
            var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();
            var broker = scope.ServiceProvider.GetRequiredService<IBroker>();

            int number = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                // Check whether the connection has been established, since the
                // BackgroundService will start immediately, before the application
                // is completely bootstrapped
                if (!broker.IsConnected)
                {
                    await Task.Delay(100, stoppingToken);
                    continue;
                }

                await ProduceMessageAsync(publisher, ++number);

                await Task.Delay(100, stoppingToken);
            }
        }

        private async Task ProduceMessageAsync(IPublisher publisher, int number)
        {
            try
            {
                await publisher.PublishAsync(
                    new OrderItemCommand()
                    {
                       // Number = number
                    });

                _logger.LogInformation("Produced {Number}", number);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to produce {Number}", number);
            }
        }
    }
}
