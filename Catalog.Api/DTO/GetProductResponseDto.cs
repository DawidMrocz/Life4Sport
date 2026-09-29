using Catalog.Api.Models;
using Microsoft.AspNetCore.Http;

namespace Catalog.Api.DTO
{
    public class GetProductResponseDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public List<CategoryModel> Categories { get; set; } = new();
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = null!;
        public decimal DiscountedPrice => BestDiscount is not null ? Price * (1 - BestDiscount.Percentage) : Price;
        public IFormFile? Photo { get; set; }

        //FLAGS
        public bool IsAvailable => Quantity > 0;
        public bool AnyComments => Comments.Count != 0;
        public bool InWishLsit { get; set; }
        public bool Discounted => BestDiscount is not null;

        //RELATIONS
        public List<CommentModel> Comments { get; set; } = new();
        public DiscountModel? BestDiscount { get; set; }

        public GetProductResponseDto(ProductModel model)
        {
            ProductId = model.ProductId;
            Name = model.Name;
            Description = model.Description;
            Categories = model.Categories;
            Quantity = model.Quantity;
            Price = model.Price;
            Comments = model.Comments;
            BestDiscount = model.BestDiscount;
        }
    }
}
