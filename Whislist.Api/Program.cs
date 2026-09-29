using Framework.Shared.Extensions;
using System.Reflection;

namespace Whislist.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

            builder.Services.AddFramework(builder.Configuration, Assembly.GetExecutingAssembly());

            builder.Services.AddHostedService<ConsumeRabbitMQHostedService>();


            WebApplication? app = builder.Build();

            app.AddFramework();
        }
    }
}