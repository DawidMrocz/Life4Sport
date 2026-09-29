using Catalog.Api.Data;
using Common;
using Framework.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Api.Models
{
    [Index(nameof(Code), IsUnique = true)]
    [EntityTypeConfiguration(typeof(DiscountConfiguration))]
    public class DiscountModel : BaseModel, IExternal
    {
        [Key]
        public int DiscountId { get; set; }     
        public int ExternalId { get; set; }
        public string Code { get; set; } = null!;
        public decimal Percentage { get; set; }
        public DateTime ValidTo { get; set; }

        //RELATIONS
        public List<ProductModel> Products { get; set; } = new();
    }
}
