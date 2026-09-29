using Common.Product;
using Microsoft.AspNetCore.Http;

namespace Catalog.Api.DTO
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = null!;
        public ProductSeasonTypeEnum Season { get; set; }
        public List<IFormFile> Photos { get; set; } = new();

        //RELATIONS
        public int CategoryId { get; set; }
        public int ProducerId { get; set; }

    }
}
