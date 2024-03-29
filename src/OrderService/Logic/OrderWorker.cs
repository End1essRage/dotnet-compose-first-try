﻿using CommunicationModel.ProductManagementRequest;
using LogModel;
using OrderService.Communication.Sender;
using OrderService.Data;
using OrderService.Data.Models;

namespace OrderService.Logic
{
    public class OrderWorker : IOrderWorker
    {
        private IOrderRepository _repository;
        private RmqSender _sender;
        private ILogSender _logger;
        public OrderWorker(IOrderRepository repository, ILogSender logger, RmqSender sender)
        {
            _repository = repository;
            _logger = logger;
            _sender = sender;
        }

        public async Task ChangeOrderStatus(int orderNumber, string status)
        {
            var order = await _repository.GetOrderByNumber(orderNumber);
            order.Status = status;
            _repository.SaveChanges(order);
        }

        public async Task<Order> CreateOrder(string userOwner)
        {
            //получить состав корзины
            List<Position> positions = new List<Position>();
            var product1 = new Product(1, "test", 12.00);
            var product2 = new Product(2, "test", 12.00);
            var product3 = new Product(3, "test", 12.00);
            positions.Add(new Position(product1, 7));
            positions.Add(new Position(product2, 8));
            positions.Add(new Position(product3, 3));
            //создать заказ
            var order = await _repository.CreateNewOrder(userOwner, positions);
            _logger.SendMessage(new LogMessage("Created order number  = " + order.OrderNumber));
            //отправить запрос на списывание
            var request = new WriteOffRequest();
            request.orderNumber = order.OrderNumber;

            foreach (var position in positions)
            {
                request.positions.Add(position.Product.Id, position.Amount);
            }

            _sender.SendMessage(request);
            _logger.SendMessage(new LogMessage("Message sended to order que"));
            return order;
        }

        public async Task<Order> GetOrder(string userOwner)
        {
            return await _repository.GetOrderByUser(userOwner);
        }
    }
}
