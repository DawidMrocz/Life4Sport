namespace Framework.Shared.Models.Template
{
    public class TemplateModel : BaseModel
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public string? Subject { get; set; }
        public string? Name { get; set; }
        public string? StrongName { get; set; }
        public string? Description { get; set; }
        public string? DataStrongName { get; set; }
        public int CultureId { get; set; }
        public string? CultureName { get; set; }
        //public IEnumerable<TemplateXFileItem> Files { get; set; }
        public IEnumerable<int> SystemPartIds { get; set; } = new List<int>();
        //public string SystemPartsJson
        //{
        //    set
        //    {
        //        SystemPartIds = JsonConvert.DeserializeObject<IEnumerable<Tuple<int>>>(value).Select(x => x.Item1);
        //    }
        //}
    }
}
