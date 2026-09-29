using Common;

namespace Comment.Api.Models
{
    public class CommentModel : BaseModel
    {
        public int CommentId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Rating { get; set; }
        public int UserId { get; set; }

        //RELATIONS
        public int ProductId { get; set; }
        public ProductModel Product { get; set; } = new();
    }
}
