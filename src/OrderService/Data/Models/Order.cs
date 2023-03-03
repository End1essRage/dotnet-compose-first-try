using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OrderService.Data.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int OrderNumber { get; set; }
        public string UserOwner { get; set; }
        public List<Position> Positions { get; set; }
        public double Cost { get; set; }
        public string Status { get; set; }

        public Order(string userOwner, int orderNumber, List<Position> positions)
        {
            UserOwner = userOwner;
            Positions = positions;
            OrderNumber = orderNumber;
            Cost = CalculateOrderCost(positions);
            Status = OrderStatus.Draft;
        }

        private double CalculateOrderCost(List<Position> positions)
        {
            double cost = 0;
            foreach(var position in positions)
            {
                cost += position.Product.Price * position.Amount;
            }
            return cost;
        }
    }
}
