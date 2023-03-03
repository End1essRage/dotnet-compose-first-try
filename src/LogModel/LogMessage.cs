using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LogModel
{
    public class LogMessage : LogMessageBase
    {
        public LogMessage()
        {

        }

        public LogMessage(string message)
        {
            this.Message = message;
            this.tag = LogMessageTag.other;
        }

        public LogMessage(string message, string tag) 
        {
            this.Message = message;
            this.tag = tag;      
        }
    }
}
