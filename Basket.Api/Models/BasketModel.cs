using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.Api.Models
{
    public class BasketModel
    {
        [Key]
        public int BasketId { get; set; }
        public int BasketUserId { get; set; }
        public BasketUserModel BasketUser { get; set; } = new();
        [NotMapped]
        public decimal TotalPrice => BasketItems.Sum(b => b.Price);


        //RELATIONS
        public List<BasketItemModel> BasketItems { get; set; } = new();

    }
}
