using Common.Silverback;

namespace Common.MassTransit
{
    public class CreateOrderCommand
    {
        public int UserId { get; set; }
        public List<OrderItemCommand> OrderItems { get; set; } = new();
        public decimal Price { get; set; }
    }
}
