using Home.Enums;

namespace Home.Dto.Product
{
    public class UpdateProductRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public ProductSeasonTypeEnum? Season { get; set; }


        //RELATIONS      
        //public int ProducerId { get; set; }
        //public ProducerModel Producer { get; set; } = null!;
        //public List<CategoryModel> Categories { get; set; } = new();
    }
}
