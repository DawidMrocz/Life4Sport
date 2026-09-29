using Framework.Shared.Attribiutes.Dependency;
using Framework.Shared.Services.User;
using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Shared.MessageBroker.RabbitMQ
{
    [DependencyInjection(typeof(IMessageProducer))]
    public class MessageProducer : IMessageProducer
    {
        public void SendMessage<T>(T message,string hostName,string queue)
        {
            ConnectionFactory factory = new() { HostName = hostName };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    byte[]? body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body);

                }
            }
        }      
    }
}
