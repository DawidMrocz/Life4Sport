using Discount.Api.Data;
using Framework.Shared.Extensions;
using System.Reflection;

namespace Discount.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DiscountDbContext>();

            builder.Services.AddFramework(builder.Configuration, Assembly.GetExecutingAssembly());

            WebApplication? app = builder.Build();

            app.AddFramework();
        }
    }
}