using Catalog.Api.Data;
using Common;
using Framework.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [EntityTypeConfiguration(typeof(CategoryConfiguration))]
    public class CategoryModel : BaseModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;

        //RELATIONS
        public List<ProductModel> Product { get; set; } = new();
    }
}
