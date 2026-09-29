namespace Framework.Shared.DataModels.Authentication
{
    public class AuthenticationUser : IAuthenticationUser
    {
        public int Id { get; set; }
        public string AuthorizeToken { get; set; } = null!;
        public DateTime? TokenExpirationDate { get; set; }
        public string Role { get; set; } = null!;
    }
}
