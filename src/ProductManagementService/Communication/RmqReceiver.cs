using CommunicationModel.ProductManagementRequest;
using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using ProductManagementService.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ProductManagementService.Communication
{
    public class RmqReceiver : BackgroundService
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;
        private RequestWorker _worker;

        public RmqReceiver(RequestWorker worker)
        {
            _queueName = "orders_que";
            _hostname = "rabbitmq";
            _username = "user";
            _password = "password";
            _worker = worker;
            InitializeRabbitMqListener();
        }
        private void InitializeRabbitMqListener()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            _connection = factory.CreateConnection();
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(exchange: "retailstore_productmanagement", type: ExchangeType.Direct);
            _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(_queueName, exchange: "retailstore_productmanagement", routingKey: "request");
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var message = JsonConvert.DeserializeObject<WriteOffRequest>(content);

                HandleMessage(message);

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            consumer.Shutdown += OnConsumerShutdown;
            consumer.Registered += OnConsumerRegistered;
            consumer.Unregistered += OnConsumerUnregistered;
            consumer.ConsumerCancelled += OnConsumerCancelled;

            _channel.BasicConsume(_queueName, false, consumer);

            return Task.CompletedTask;
        }

        //ToDo refactor
        private async void HandleMessage(WriteOffRequest request)
        {
            _worker.HandleRequest(request);
        }

        private void OnConsumerCancelled(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
        }

        private void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
