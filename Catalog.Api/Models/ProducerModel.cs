using Catalog.Api.Data;
using Common;
using Framework.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.Models
{
    [Index(nameof(Name), IsUnique = true)]
    [EntityTypeConfiguration(typeof(ProducerConfiguration))]
    public class ProducerModel : BaseModel
    {
        [Key]
        public int ProducerId { get; set; }
        public string Name { get; set; } = null!;
        public int? FileId { get; set; }

        //RELATION
        public List<ProductModel> Product { get; set; }  = new();
    }
}
