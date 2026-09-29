using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Whislist.Api.Models
{
    public class WishItemModel
    {
        [Key]
        public int WishItemId { get; set; }

        //RELATIONS
        public int WishId { get; set; }
        public WishModel Wish { get; set; } = new();
        public int ProductId { get; set; } = new();
        public ProductModel Product { get; set; } = new();
    }
}
