using System.ComponentModel.DataAnnotations;

namespace Discount.Data.DataModels
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        public int ExternalProductId { get; set; }
    }
}
