using Home.Enums;

namespace Home.Dto.Product
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductSeasonTypeEnum Season { get; set; }
    }
}
