using Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Basket.Api.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class ProductModel : IExternal
    {
        [Key]
        public int ProductId { get; set; }
        public int ExternalId { get; set; }
        public string Name { get; set; } = null!;
        public int InStock { get; set; }
        public decimal Price { get; set; } = new();
        public List<int> Photos { get; set; } = new();


        //FLAGS
        //[NotMapped]
        //public decimal BestDiscountPrice => BestDiscount is not null ? Price * (1 - BestDiscount.Percentage) : Price;
        //[NotMapped]
        //public DiscountModel? BestDiscount => Discounts.MaxBy(d => d.Percentage);
        [NotMapped]
        public bool IsAvailable => InStock > 0;


        //RELATIONS
        public int ProducerId { get; set; }
        public ProducerModel Producer { get; set; } = new();
        public BasketItemModel BasketItem { get; set; } = new();
        public List<CategoryModel> Categories { get; set; } = new();
    }
}
