using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LogModel
{
    public class LogMessageBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Message { get; set; }

        public string? ServiceName { get; set; }

        public string tag { get; set; }

        public DateTime dateTime { get; set; }
    }
}
