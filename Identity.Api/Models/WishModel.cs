using System.ComponentModel.DataAnnotations;

namespace Whislist.Api.Models
{
    public class WishModel
    {
        [Key]
        public int WishId { get; set; }
        public int UserId { get; set; }
        public int Quantity => WishItems.Count;

        //RELATIONS
        public List<WishItemModel> WishItems { get; set; } = new();
    }
}
