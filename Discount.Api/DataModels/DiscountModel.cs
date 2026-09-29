using System.ComponentModel.DataAnnotations;

namespace Discount.Data.DataModels
{
    public class DiscountModel
    {
        [Key]
        public int DiscountId { get; set; }
        public string Code { get; set; } = null!;
        public decimal Percentage { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime Created { get; set; }

        //RELATIONS
        public List<ProductModel> Products { get; set; } = new();
    }
}
