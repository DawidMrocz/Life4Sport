using Catalog.Api.Models;
using Microsoft.AspNetCore.Http;

namespace Catalog.Api.DTO
{
    public class UpdateProductRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<int> CategoryIds { get; set; } = new();
        public int? ProducerId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
