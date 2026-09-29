using Framework.Shared.Extensions;
using MassTransit;
using System.Reflection;

namespace Identity.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

            builder.Services.AddFramework(builder.Configuration, Assembly.GetExecutingAssembly());

            builder.Services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
                {
                    busFactoryConfigurator.Host(builder.Configuration["RabbitMqSettings:Uri"], hostConfgurator => { });
                });
            });

            WebApplication? app = builder.Build();

            app.AddFramework();
        }
    }
}