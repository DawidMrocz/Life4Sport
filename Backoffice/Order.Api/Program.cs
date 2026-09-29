
using Framework.Shared.Extensions;
using Order.Api.Data;
using System.Reflection;

namespace Order.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<OrderDbContext>();
            builder.Services.AddFramework(builder.Configuration, Assembly.GetExecutingAssembly());

            //builder.Services
            //    .AddSilverback()

            //    // Use Apache Kafka as message broker
            //    .WithConnectionToMessageBroker(
            //        options => options
            //            .AddKafka())

            //    // Delegate the inbound/outbound endpoints configuration to a separate
            //    // class.
            //    .AddKafkaEndpoints(
            //        endpoints => endpoints

            //            // Configure the properties needed by all consumers/producers
            //            .Configure(
            //                config =>
            //                {
            //                    // The bootstrap server address is needed to connect
            //                    config.BootstrapServers =
            //                        "PLAINTEXT://kafka:9092";
            //                })

            //            // Consume the samples-basic topic
            //            .AddInbound(endpoint => endpoint
            //            .ConsumeFrom("create-order")
            //            .OnError(error => error
            //                .Retry(3, TimeSpan.FromSeconds(1))
            //                .ThenSkip())
            //            .Configure(config =>
            //            {
            //                config.GroupId = "Medicover.SSF.Api";
            //                config.AutoOffsetReset = AutoOffsetReset.Latest;
            //            })))
            //    .AddSingletonSubscriber<CreateOrderSubscriber>();


            WebApplication? app = builder.Build();

            app.AddFramework();
        }
    }
}
