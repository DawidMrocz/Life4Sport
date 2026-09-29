namespace Framework.Shared.MessageBroker.RabbitMQ
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message, string hostName, string queue);
    }
}