using Home.Models.Category;
using Home.Models.Product;

namespace Home.Dto.Product
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
        public IFormFile? Photo { get; set; }

        //FLAGS
        public bool IsAvailable => Quantity > 0;


        public GetProductResponseDto(ProductModel model)
        {
            ProductId = model.ProductId;
            Name = model.Name;
            Description = model.Description;
            Categories = model.Categories;
            Quantity = model.Quantity;
            Price = model.Price;
        }
    }
}
