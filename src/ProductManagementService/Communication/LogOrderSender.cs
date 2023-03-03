using LogModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ProductManagementService.Communication
{
    public class LogProductManagementSender : ILogSender
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _username;
        private IConnection _connection;

        public LogProductManagementSender()
        {
            _queueName = "logs_que";
            _hostname = "rabbitmq";
            _username = "user";
            _password = "password";

            CreateConnection();
        }

        private LogMessage FormatMessage(LogMessage message)
        {
            message.ServiceName = "ProductManagementService";
            message.dateTime = DateTime.Now.AddHours(3);
            return message;
        }

        public void SendMessage(LogMessage message)
        {
            FormatMessage(message);
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "retailstore_logs", type: ExchangeType.Direct);
                    channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var json = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "retailstore_logs", routingKey: "test", basicProperties: null, body: body);
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
