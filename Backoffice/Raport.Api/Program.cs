using Framework.Shared.Extensions;
using Raport.Api.Data;
using System.Reflection;

namespace Raport.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<RaportDbContext>();

            builder.Services.AddFramework(builder.Configuration, Assembly.GetExecutingAssembly());

            WebApplication? app = builder.Build();

            app.AddFramework();
        }
    }
}
