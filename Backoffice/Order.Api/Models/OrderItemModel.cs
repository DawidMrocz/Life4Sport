using System.ComponentModel.DataAnnotations;

namespace Order.Api.Models
{
    public class OrderItemModel
    {
        [Key]
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //RELATIONS
        public int OrderId { get; set; }
        public OrderModel Order { get; set; } = new();
        public int ProductId { get; set; }
        public ProductModel Product { get; set; } = new();
    }
}
