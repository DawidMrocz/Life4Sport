using Discount.Data.DataModels;

namespace Discount.Api.ApiModels
{
    public class UpdateDiscountRequest
    {
        public decimal? Percentage { get; set; }
        public DateTime? ValidTo { get; set; }
        public List<int>? Products { get; set; }
    }
}
