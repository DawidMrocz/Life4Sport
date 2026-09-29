using Common.Silverback;
using MassTransit;
using Silverback.Messaging.Configuration;

namespace Basket.Api.MessageBrokers.Silverback
{
    public class EndpointsConfigurator : IEndpointsConfigurator
    {
        public void Configure(IEndpointsConfigurationBuilder builder)
        {
            builder
                .AddKafkaEndpoints(
                    endpoints => endpoints

                        // Configure the properties needed by all consumers/producers
                        .Configure(
                            config =>
                            {
                                // The bootstrap server address is needed to connect
                                config.BootstrapServers =
                                    "PLAINTEXT://localhost:9092";
                            })

                        .AddOutbound<OrderItemCommand>(
                            endpoint => endpoint
                                .ProduceTo("create-order")));
        }
    }
}
