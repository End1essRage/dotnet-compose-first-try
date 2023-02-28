using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace CartService.Data.Models
{
    public class Cart 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserOwner { get; set; }
        public List<Position> Positions { get; set; }
        public Cart(string userOwner) 
        { 
            this.UserOwner = userOwner;
            this.Positions = new List<Position>();
        }
    }
}
