using Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Basket.Api.Models
{
    [Index(nameof(Code), IsUnique = true)]
    public class DiscountModel : IExternal
    {
        [Key]
        public int DiscountId { get; set; }
        public int ExternalId { get; set; }
        public string Code { get; set; } = null!;
        public decimal Percentage { get; set; }
        public DateTime ValidTo { get; set; }
        public bool Used { get; set; }

        //RELATIONS
        public List<ProductModel> Products { get; set; } = new();
        public int BasketUserId { get; set; }
        public BasketUserModel BasketUser { get; set; } = new();
    }
}
