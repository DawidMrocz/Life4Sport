using Common;
using Framework.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace Order.Api.Models
{
    public class OrderModel : BaseModel
    {
        [Key]
        public int OrderId { get; set; }      
        public OrderStatusEnum OrderStatus { get; set; }
        public decimal VAT { get; set; }
        public decimal TotalQuantity => OrderItems.Count;
        public decimal TotalPrice => OrderItems.Sum(o => o.Quantity * o.Price) * (1 - VAT);

        //RELATIONS
        public int UserId { get; set; }
        public List<OrderItemModel> OrderItems { get; set; } = new();
    }
}
