namespace Framework.Shared.Models.File
{
    public class FileModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public byte[]? Content { get; set; }
        public Guid? FileGuid { get; set; }
    }
}
