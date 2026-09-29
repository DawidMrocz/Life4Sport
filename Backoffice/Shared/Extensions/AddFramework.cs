using Framework.Shared.Configuration;
using Framework.Shared.Data;
using Framework.Shared.Enums;
using Framework.Shared.Services.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Framework.Shared.Extensions
{
    public static class AddFrameworkExtension
    {
        public static IApplicationBuilder AddFramework(this WebApplication app)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            //app.UseHttpsRedirection();
            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Lax,
                Secure = Enum.Parse<CookieSecurePolicy>(FrameworkConfiguration.CookieSecurePolicy),
                HttpOnly = FrameworkConfiguration.CookieHttpOnly
                ? Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always
                : Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.None
            });

            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials());

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();

            return app;
        }


        public static IServiceCollection AddFramework(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
        {
            services.AddControllers().AddApplicationPart(typeof(AddFrameworkExtension).Assembly);
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
               {
                 new OpenApiSecurityScheme
                 {
                   Reference = new OpenApiReference
                   {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                   }
                  },
                  new string[] { }
                }
              });
            });

            FrameworkConfiguration.SetConfiguration(configuration, assembly.FullName);

            services.AddDependencyInjections(assembly);

            services.AddDbContext<FrameworkDbContext>();



            services.AddMemoryCache();
            services.AddDistributedMemoryCache();


            services.AddHttpContextAccessor();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(4);
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "SessionCookie";
            });

            services.AddKeyedScoped<IAuthenticationService, AuthenticationService_Cookie>(AuthorizationProviderEnum.Cookie.ToString());
            services.AddKeyedScoped<IAuthenticationService, AuthenticationService_JWT>(AuthorizationProviderEnum.JWT.ToString());

            services.AuthorizationProvider(FrameworkConfiguration.AuthorizationProvider);

            return services;
        }
    }
}


