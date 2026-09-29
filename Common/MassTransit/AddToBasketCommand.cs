namespace Common.MassTransit
{
    public class AddToBasketCommand
    {
        public AddToBasketCommand(int userId, int productId, int quantity)
        {
            UserId=userId;
            ProductId=productId;
            Quantity=quantity;
        }

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
