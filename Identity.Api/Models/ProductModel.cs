using Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Whislist.Api.Models
{
    public class ProductModel : IExternal
    {
        public int ProductId { get; set; }
        public int ExternalId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int InStock { get; set; }
        public int Photo { get; set; }
        public decimal Price { get; set; } = new();


        //FLAGS
        [NotMapped]
        public decimal BestDiscountPrice => BestDiscount is not null ? Price * (1 - BestDiscount.Percentage) : Price;
        [NotMapped]
        public DiscountModel? BestDiscount => Discounts.MaxBy(d => d.Percentage);
        [NotMapped]
        public bool IsAvailable => InStock > 0;

        //RELATIONS      
        public List<DiscountModel> Discounts { get; set; } = new();     
        public WishItemModel WishItem { get; set; } = new();
    }
}