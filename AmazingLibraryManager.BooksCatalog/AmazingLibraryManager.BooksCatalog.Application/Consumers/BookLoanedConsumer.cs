using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AmazingLibraryManager.BooksCatalog.Application.Consumers
{
    public class BookLoanedConsumer : BackgroundService
    {
        private IServiceProvider _serviceProvider;
        private readonly IModel _channel;
        private const string Queue = "book.book-loaned";
        private const string Exchange = "book-loan";
        private const string RoutingKey = "book-loaned";

        public BookLoanedConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var connectionFactory = new ConnectionFactory() 
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("book.book-loaned");

            _channel = connection.CreateModel();

            _channel.QueueDeclare(Queue, true, false, false, null);

            _channel.ExchangeDeclare(Exchange, "direct", true, false);

            _channel.QueueBind(Queue, Exchange, RoutingKey);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken) 
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) => 
            {
                var contentArray = eventArgs.Body.ToArray();
                var json = Encoding.UTF8.GetString(contentArray);
                var @event = JsonConvert.DeserializeObject<BookLoaned>(json);

                Console.WriteLine(json);

                await RegisterBookLoan(@event);

                // _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
            
            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }

        private async Task RegisterBookLoan(BookLoaned @event) 
        {

        }
    }

    public class BookLoaned
    {
        public Guid UserId { get; set; }
        public List<Guid> BookIds { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}