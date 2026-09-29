namespace Framework.Shared.Models.Setting
{
    public class SettingModel : BaseModel
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
        public string? Description { get; set; }
    }
}
