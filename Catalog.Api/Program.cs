using Catalog.Api.Data;
using Common.Silverback;
using Framework.Shared.Extensions;
using MassTransit;
using System.Reflection;

namespace Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CatalogContext>();
            builder.Services.AddFramework(builder.Configuration, Assembly.GetExecutingAssembly());

            builder.Services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
                {
                    busFactoryConfigurator.Host(builder.Configuration["RabbitMqSettings:Uri"], hostConfgurator => { });
                });
            });

            builder.Services
                .AddSilverback()
                .UseModel()

                // Use Apache Kafka as message broker
                .WithConnectionToMessageBroker(
                    options => options
                        .AddKafka())
                .AddKafkaEndpoints(
                        endpoints => endpoints
                            .Configure(
                            config =>
                            {
                                // The bootstrap server address is needed to connect
                                config.BootstrapServers =
                                    "PLAINTEXT://kafka:9092";
                            })
                             .AddOutbound<SynchronizeProducts>(
                            endpoint => endpoint
                                .ProduceTo("synchronize-products")));

            //builder.Services.AddHostedService<ConsumeRabbitMQHostedService>();

            WebApplication? app = builder.Build();

            app.AddFramework();
        }
    }
}

