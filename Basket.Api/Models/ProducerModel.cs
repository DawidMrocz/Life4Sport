using Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Basket.Api.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class ProducerModel : IExternal
    {
        [Key]
        public int ProducerId { get; set; }
        public int ExternalId { get; set; }
        public string Name { get; set; } = null!;
        public int FileId { get; set; }

        //RELATION
        public ProductModel Product { get; set; } = null!;
    }
}
