namespace Framework.Shared.DataModels.Authentication
{
    public interface IAuthenticationUser
    {
        public int Id { get; set; }
        public string AuthorizeToken { get; set; }
        public DateTime? TokenExpirationDate { get; set; }
        public string Role { get; set; }
    }
}
