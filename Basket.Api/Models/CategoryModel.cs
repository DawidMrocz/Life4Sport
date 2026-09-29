using Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Basket.Api.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class CategoryModel : IExternal
    {
        [Key]
        public int CategoryId { get; set; }
        public int ExternalId { get; set; }
        public string Name { get; set; } = null!;

        //RELATIONS
        public List<ProductModel> Products { get; set; } = new();
    }
}
