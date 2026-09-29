using Silverback.Messaging.Messages;

namespace Common.Silverback
{
    public class OrderItemCommand : IIntegrationEvent
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; } = new();
    }
}
