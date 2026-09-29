namespace Framework.Shared.Models.File
{
    public class FileModel : BaseModel
    {
        public string Name { get; set; } = null!;
        public byte[]? Content { get; set; }
        public Guid FileGuid { get; set; }
        public int? UserId { get; set; }
        public string? Role { get; set; }
    }
}
