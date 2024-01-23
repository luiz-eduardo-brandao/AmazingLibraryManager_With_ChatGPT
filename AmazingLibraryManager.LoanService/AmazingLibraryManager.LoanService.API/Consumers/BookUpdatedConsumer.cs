using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AmazingLibraryManager.LoanService.API.Consumers
{
    public class BookUpdatedConsumer : BackgroundService
    {
        private readonly IModel _channel;
        private const string Queue = "book.book-updated";
        private const string Exchange = "book-catalog";
        private const string RoutingKey = "book-updated";

        public BookUpdatedConsumer()
        {
            var connectionFactory = new ConnectionFactory() 
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("book-updated.consumer");

            _channel = connection.CreateModel();

            _channel.QueueDeclare(Queue, true, false, false);

            _channel.ExchangeDeclare(Exchange, "direct", true, false);

            _channel.QueueBind(Queue, Exchange, RoutingKey);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) 
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) => 
            {
                var array = eventArgs.Body.ToArray();
                var json = Encoding.UTF8.GetString(array);
                var @event = JsonConvert.DeserializeObject<BookUpdated>(json);

                Console.WriteLine(@json);

                await RegisterBookUpdated(@event);

                // _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }

        private async Task RegisterBookUpdated(BookUpdated @event) 
        {

        }
    }



    public class BookUpdated 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}