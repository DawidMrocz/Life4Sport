using Framework.Shared.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Basket.Api.Models
{
    public class BasketItemModel
    {
        [Key]
        public int BasketItemId { get; set; }
        public int Quantity { get; set; } = 0;
        [NotMapped]
        public decimal Price => Product.Price * Quantity;
        [NotMapped]
        //public decimal DiscountedPrice => Product.BestDiscountPrice * Quantity;


        //RELATIONS
        public int BasketId { get; set; }
        public BasketModel Basket { get; set; } = new();
        public int ProductId { get; set; } = new();
        public ProductModel Product { get; set; } = new();
    }
}
