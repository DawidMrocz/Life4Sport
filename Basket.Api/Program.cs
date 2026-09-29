using Basket.Api.Consumers.RabbitMQ;
using Basket.Api.Data;
using Common.Silverback;
using Framework.Shared.Extensions;
using MassTransit;
using System.Reflection;

namespace Basket.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<BasketDbContext>();
            builder.Services.AddFramework(builder.Configuration, Assembly.GetExecutingAssembly());

            builder.Services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumers(Assembly.GetExecutingAssembly());
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.UsingRabbitMq((context, busFactoryConfiguration) =>
                {
                    busFactoryConfiguration.Host(builder.Configuration["RabbitMqSettings:Uri"]);
                    busFactoryConfiguration.ConfigureEndpoints(context);
                });
            });

            //builder.Services
            //    .AddSilverback()
            //    .UseModel()

            //    // Use Apache Kafka as message broker
            //    .WithConnectionToMessageBroker(
            //        options => options
            //            .AddKafka())
            //    .AddKafkaEndpoints(
            //            endpoints => endpoints
            //                .Configure(
            //                config =>
            //                {
            //                    // The bootstrap server address is needed to connect
            //                    config.BootstrapServers =
            //                        "PLAINTEXT://kafka:9092";
            //                })
            //                 .AddOutbound<OrderItemCommand>(
            //                endpoint => endpoint
            //                    .ProduceTo("create-order")));


            //// Add the hosted service that produces the random sample messages
            ///
            //builder.Services.AddHostedService<ConsumeRabbitMQHostedService>();

            WebApplication? app = builder.Build();

            app.AddFramework();
        }
    }
}