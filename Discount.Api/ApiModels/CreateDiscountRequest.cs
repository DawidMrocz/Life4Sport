namespace Discount.Api.ApiModels
{
    public class CreateDiscountRequest
    {
        public string Code { get; set; } = null!;
        public decimal Percentage { get; set; }
        public DateTime ValidTo { get; set; }

        //RELATIONS
        public List<int> Products { get; set; } = new();
    }
}
