using Framework.Shared.Enums;
using Microsoft.Extensions.Configuration;

namespace Framework.Shared.Configuration
{
    public static class FrameworkConfiguration
    {

        private static IConfiguration _configuration = null!;
        public static string ExecutingAssemblyName = null!;
        public static void SetConfiguration(IConfiguration configuration, string? executingAssemblyName)
        {
            _configuration = configuration;
            ExecutingAssemblyName = executingAssemblyName ?? throw new Exception("Assembly name not provided");
        }

        //RABBITMQ
        public static string RabbitMQ_Host => _configuration["RabbitMqSettings:Uri"] ?? throw new Exception("RabbitMQ host not found");
        public static string RabbitMQ_Name => _configuration["RabbitMqSettings:UserName"] ?? "None";
        public static string RabbitMQ_Password => _configuration["RabbitMqSettings:Password"] ?? "None";

        public static string AuthorizationProvider => _configuration["IdentityOptions:AuthorizationProvider"] ?? AuthorizationProviderEnum.Cookie.ToString();
        public static int SessionTimeout => int.Parse(_configuration["IdentityOptions:SessionTimeout"] ?? "15");

        //PASSWORD AUTH
        public static int Lenght => int.Parse(_configuration["IdentityOptions:Password:Lenght"] ?? "6");
        public static bool ContainNumbers => bool.Parse(_configuration["IdentityOptions:Password:ContainNumbers"] ?? "false");
        public static bool ContainSpecialSigns => bool.Parse(_configuration["IdentityOptions:Password:ContainSpecialSigns"] ?? "false");
        public static bool ContainBigLetters => bool.Parse(_configuration["IdentityOptions:Password:ContainBigLetters"] ?? "false");
        //COOKIE AUTH
        public static string CookieName => _configuration["IdentityOptions:Cookie:CookieName"] ?? "IdentityCookie";
        public static string CookieSameSite => _configuration["IdentityOptions:Cookie:CookieSameSite"] ?? "None";
        public static string CookieSecurePolicy => _configuration["IdentityOptions:Cookie:CookieSecurePolicy"] ?? "None";
        public static bool CookieHttpOnly => bool.Parse(_configuration["IdentityOptions:Cookie:CookieHttpOnly"] ?? "false");
        public static string? DomainToSaveCookies => _configuration["IdentityOptions:Cookie:DomainToSaveCookies"] ?? null;
        public static string? CookieDecryptionKey => _configuration["IdentityOptions:Cookie:CookieDecryptionKey"] ?? null;
        public static string? CookieValidationKey => _configuration["IdentityOptions:Cookie:CookieValidationKey"] ?? null;

        //JWT AUTH
        public static string? JwtPublicKey => _configuration["IdentityOptions:Jwt:PublicKey"] ?? "KluczPubliczny";
        public static string? Issuer => _configuration["IdentityOptions:Jwt:Issuer"] ?? "KluczPubliczny";
        public static string? Audience => _configuration["IdentityOptions:Jwt:Audience"] ?? "KluczPubliczny";
        public static string? JwtPrivateKey => _configuration["IdentityOptions:Jwt:PrivateKey"] ?? "KluczPrywatny";
        public static int? JwtTokenLifetime => int.Parse(_configuration["IdentityOptions:Jwt:TokenLifetime"] ?? "1");
        public static string? JwtRefreshTokenCookieName => _configuration["IdentityOptions:Jwt:RefreshTokenCookieName"] ?? "RefreshCookie";
        public static int? JwtRefreshTokenLifetimeInMinutes => int.Parse(_configuration["IdentityOptions:Jwt:RefreshTokenLifetimeInMinutes"] ?? "360");

        public static string ConnectionString => _configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        public static string SaveFilePath => _configuration["SharedOptions:File:SaveFilePath"] ?? throw new Exception("Connection string not provided");
        public static string EmailServer => _configuration["SharedOptions:Email:Server"] ?? throw new Exception("Email server not provided");
        public static int EmailPort => int.Parse(_configuration["SharedOptions:Email:Port"] ?? throw new Exception("Email port not provided"));
        public static string User => _configuration["SharedOptions:Email:User"] ?? throw new Exception("Email user not provided");
        public static string Password => _configuration["SharedOptions:Email:Password"] ?? throw new Exception("Email password not provided");
        public static bool EnableSSL => bool.Parse(_configuration["SharedOptions:Email:SSL"] ?? throw new Exception("Email password not provided"));

    }
}
