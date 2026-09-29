using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;
using Home.Data.Configurations;
using Home.Models.Category;
using Home.Models.Producer;
using Home.Enums;

namespace Home.Models.Product
{
    [Index(nameof(Name), IsUnique = true)]
    [EntityTypeConfiguration(typeof(ProductConfiguration))]
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; } = new();
        public ProductSeasonTypeEnum Season { get; set; }
        public List<int> Photos { get; set; } = new();

        [NotMapped]
        public bool IsAvailable => Quantity > 0;


        //RELATIONS      
        public int ProducerId { get; set; }
        public ProducerModel Producer { get; set; } = null!;
        public List<CategoryModel> Categories { get; set; } = new();
    }
}
