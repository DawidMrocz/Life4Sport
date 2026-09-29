using Common;

namespace Comment.Api.Models
{
    public class ProductModel : IExternal
    {
        public int ProductId { get; set; } 
        public int ExternalId { get; set; }

        //RELATIONS     
        public List<CommentModel> Comments { get; set; } = new();
    }
}
