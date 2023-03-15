using CommunicationModel.ProductManagementRequest;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ProductManagementService.Communication
{
    public class RmqSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _username;
        private IConnection _connection;

        public RmqSender()
        {
            _queueName = "orders_que";
            _hostname = "rabbitmq";
            _username = "user";
            _password = "password";

            CreateConnection();
        }

        public void SendMessage(ProductManagementAnswer answer)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "retailstore_productmanagement", type: ExchangeType.Direct);
                    channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var json = JsonConvert.SerializeObject(answer);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "retailstore_productmanagement", routingKey: "answer", basicProperties: null, body: body);
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
