using Home.Data.Configurations;
using Home.Models.Product;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Home.Models.Producer
{
    [Index(nameof(Name), IsUnique = true)]
    [EntityTypeConfiguration(typeof(ProducerConfiguration))]
    public class ProducerModel
    {
        [Key]
        public int ProducerId { get; set; }
        public string Name { get; set; } = null!;
        public int? FileId { get; set; }

        //RELATION
        public List<ProductModel> Product { get; set; } = new();
    }
}
