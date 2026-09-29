using Framework.Shared.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Shared.Extensions
{
    public static class AuthorizationProviderExtension
    {
        public static IServiceCollection AuthorizationProvider(this IServiceCollection services, string authorizationProviderEnum)
        {
            switch (authorizationProviderEnum)
            {
                case "Cookie":
                    //       services.AddDataProtection()
                    // .PersistKeysToFileSystem(new DirectoryInfo(Configuration.KeyStorePath))
                    //.SetApplicationName(Configuration.ApplicationName)
                    //.SetDefaultKeyLifetime(TimeSpan.FromDays(90));
                    //}

                    //MT autentykacja cookie
                    services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    }).AddCookie(options =>
                    {
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                        options.SlidingExpiration = true;
                        options.AccessDeniedPath = "/Forbidden/";


                        //options.Cookie.Name = IdentityConfiguration.CookieName;
                        //options.Cookie.Path = "/";
                        //options.Cookie.SameSite = Enum.Parse<SameSiteMode>(IdentityConfiguration.CookieSameSite);
                        //options.Cookie.SecurePolicy = Enum.Parse<CookieSecurePolicy>(IdentityConfiguration.CookieSecurePolicy);
                        //options.Cookie.HttpOnly = IdentityConfiguration.CookieHttpOnly;
                        //options.Cookie.Domain = IdentityConfiguration.DomainToSaveCookies;
                        //options.Events = new CookieAuthenticationEvents
                        //{
                        //    OnRedirectToLogin = redirectContext =>
                        //    {
                        //        redirectContext.HttpContext.Response.StatusCode = 401;
                        //        return Task.CompletedTask;
                        //    }
                        //};
                    });
                    break;

                case "JWT":
                    services.AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    }).AddJwtBearer(x =>
                    {
                        //x.Audience = FrameworkConfiguration.Issuer;
                        //x.Authority = FrameworkConfiguration.Audience;
                        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {
                            ValidIssuer = FrameworkConfiguration.Issuer, // jakie api wydaje token
                            ValidAudience = FrameworkConfiguration.Audience, // jakie api są dopuszczone do pobrania tokenów
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(FrameworkConfiguration.JwtPrivateKey!)),
                            //IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(FrameworkConfiguration.JwtPublicKey!)),
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,

                        };
                        x.RequireHttpsMetadata = false; // nie wymuszamy od klienta, że ma być tylko HTTPS
                        x.SaveToken = true; // token powinien być zapisany na serwerze

                        //// options.TokenValidationParameters = tokenValidationParameters;
                        //x.Events = new JwtBearerEvents();
                        //x.Events.OnAuthenticationFailed = (c) =>
                        //{
                        //    Console.WriteLine(c.Exception.Message);
                        //    Console.WriteLine(c.Exception.StackTrace);

                        //    //var respone = new VeloceApiRespone<int>("Veloce.Framework.Api.JWT.Token.Validation.Fail", -1);
                        //    //c.Response.WriteAsJsonAsync(respone).Wait();

                        //    return Task.CompletedTask;

                        //};
                        //x.Events.OnTokenValidated = context =>
                        //{
                        //    //if (!context.Principal.Identity.IsAuthenticated)
                        //    //{
                        //    //    var respone = new VeloceApiRespone<int>("Veloce.Framework.Api.JWT.Token.Validation.Fail", -2);
                        //    //    context.Response.WriteAsJsonAsync(respone).Wait();
                        //    //}

                        //    return Task.CompletedTask;
                        //};
                    });
                    break;

                //case "JWT":
                //    services.AddAuthentication(options =>
                //    {
                //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                //    }).AddJwtBearer(x =>
                //    {
                //        x.Audience = FrameworkConfiguration.Issuer;
                //        x.Authority = FrameworkConfiguration.Audience;
                //        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                //        {
                //           // ValidIssuer = FrameworkConfiguration.Issuer, // jakie api wydaje token
                //            //ValidAudience = FrameworkConfiguration.Audience, // jakie api są dopuszczone do pobrania tokenów
                //           // IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(FrameworkConfiguration.JwtPublicKey!)),
                //            //IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(FrameworkConfiguration.JwtPublicKey!)),
                //          //  ValidateIssuer = true,
                //            //ValidIssuers = new[] { SsoAuthority },
                //           // ValidateAudience = true,
                //            //ValidateLifetime = true,
                //            //ValidateIssuerSigningKey = true,
                //            //RequireExpirationTime = true,
                //            //RequireSignedTokens = true,
                //        };
                //        x.RequireHttpsMetadata = false; // nie wymuszamy od klienta, że ma być tylko HTTPS
                //        x.SaveToken = true; // token powinien być zapisany na serwerze

                //        //// options.TokenValidationParameters = tokenValidationParameters;
                //        //x.Events = new JwtBearerEvents();
                //        //x.Events.OnAuthenticationFailed = (c) =>
                //        //{
                //        //    Console.WriteLine(c.Exception.Message);
                //        //    Console.WriteLine(c.Exception.StackTrace);

                //        //    //var respone = new VeloceApiRespone<int>("Veloce.Framework.Api.JWT.Token.Validation.Fail", -1);
                //        //    //c.Response.WriteAsJsonAsync(respone).Wait();

                //        //    return Task.CompletedTask;

                //        //};
                //        //x.Events.OnTokenValidated = context =>
                //        //{
                //        //    //if (!context.Principal.Identity.IsAuthenticated)
                //        //    //{
                //        //    //    var respone = new VeloceApiRespone<int>("Veloce.Framework.Api.JWT.Token.Validation.Fail", -2);
                //        //    //    context.Response.WriteAsJsonAsync(respone).Wait();
                //        //    //}

                //        //    return Task.CompletedTask;
                //        //};
                //    });
                //    break;
            };
            return services;
        }
    }
}
//rsa.ImportRSAPrivateKey(
//                   source: Convert.FromBase64String(FrameworkConfiguration.JwtPrivateKey!),
//                   bytesRead: out int _);
//var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(FrameworkConfiguration.JwtPrivateKey!));

//var signingCredentials = new SigningCredentials(
//   key: new RsaSecurityKey(rsa),
//   algorithm: SecurityAlgorithms.RsaSha256)
//{
//    CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
//};


//var jwt = new JwtSecurityToken(
//    audience: FrameworkConfiguration.Audience,
//    issuer: FrameworkConfiguration.Issuer,
//    claims: claims,
//    notBefore: null,
//    expires: FrameworkConfiguration.JwtTokenLifetime != null ? DateTime.UtcNow.AddHours((double)FrameworkConfiguration.JwtTokenLifetime) : DateTime.UtcNow.AddHours(1),
//    signingCredentials: signingCredentials
//);