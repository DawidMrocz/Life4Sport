namespace Framework.Shared.Models.Culture
{
    public class CultureModel : BaseModel
    {
        public string Name { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string? Icon { get; set; }
    }
}
