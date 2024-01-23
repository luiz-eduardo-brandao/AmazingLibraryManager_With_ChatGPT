using System.Text;
using AmazingLibraryManager.BooksCatalog.Infrastructure.Extensions;
using Newtonsoft.Json;
using RabbitMQ.Client;
using AmazingLibraryManager.BooksCatalog.Core.Events;

namespace AmazingLibraryManager.BooksCatalog.Infrastructure.EventBus
{
    public class RabbitMqService : IEventBus
    {
        private readonly IModel _channel;
        private const string Exchange = "book-catalog";

        public RabbitMqService()
        {
            var connectionFactory = new ConnectionFactory() 
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("book-catalog.publisher");

            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(Exchange, "direct", true, false);
        }

        public void Publish<T>(T @event) 
        {
            var routingKey = @event.GetType().Name.ToDashCase();

            var json = JsonConvert.SerializeObject(@event);
            var bytes = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(Exchange, routingKey, null, bytes);
        }
    }
}