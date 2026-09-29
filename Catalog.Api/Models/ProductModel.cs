using Catalog.Api.Data;
using Common;
using Common.Product;
using Framework.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Catalog.Api.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [EntityTypeConfiguration(typeof(ProductConfiguration))]
    public class ProductModel : BaseModel
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } = new();
        public ProductSeasonTypeEnum Season { get; set; }
        public List<int> Photos { get; set; } = new();


        //FLAGS
        [NotMapped]
        public decimal BestDiscountPrice => BestDiscount is not null ? Price * (1 - BestDiscount.Percentage) : Price;
        [NotMapped]
        public DiscountModel? BestDiscount => Discounts.MaxBy(d => d.Percentage);
        [NotMapped]
        public bool IsAvailable => Quantity > 0;
        [NotMapped]
        public int CommentsQuantity => Comments.Count;
        [NotMapped]
        public double Rating => Comments.Sum(c => c.Rating) / Comments.Count;


        //RELATIONS      
        public int ProducerId { get; set; }
        public ProducerModel Producer { get; set; } = null!;
        public List<CategoryModel> Categories { get; set; } = new();
        public List<CommentModel> Comments { get; set; } = new();
        public List<DiscountModel> Discounts { get; set; } = new();
    }
}
