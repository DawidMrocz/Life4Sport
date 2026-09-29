using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using Home.Data.Configurations;
using Home.Models.Product;

namespace Home.Models.Category
{
    [Index(nameof(Name), IsUnique = true)]
    [EntityTypeConfiguration(typeof(CategoryConfiguration))]
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;

        //RELATIONS
        public List<ProductModel> Product { get; set; } = new();
    }
}
