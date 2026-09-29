namespace Common.MassTransit
{
    public class UserCreated
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string? Login { get; set; }
        public string Role { get; set; } = null!;
        public Files Files { get; set; } = new();
        public Address? Address { get; set; }
    }
}
