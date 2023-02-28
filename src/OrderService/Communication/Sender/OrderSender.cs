using Microsoft.Extensions.Options;
using MongoDB.Driver.Core.Connections;
using Newtonsoft.Json;
using OrderService.Communication.Options;
using OrderService.Data.Models;
using RabbitMQ.Client;
using System.Text;

namespace OrderService.Communication.Sender
{
    public class OrderSender : IOrderSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _username;
        private RabbitMQ.Client.IConnection _connection;

        public OrderSender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _queueName = "OrdersQueue";
            _hostname = "rabbitmq";
            _username = "user";
            _password = "password";

            CreateConnection();
        }

        public void SendOrderPositionsInfo(List<Tuple<int, int>> positions)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var json = JsonConvert.SerializeObject(positions);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
                }
            }
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }
    }
}
