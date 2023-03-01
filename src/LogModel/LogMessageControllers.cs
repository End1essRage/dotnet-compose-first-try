using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LogModel
{
    public class LogMessageControllers : LogMessageBase
    {
        public LogMessageControllers()
        {

        }

        public LogMessageControllers(string message)
        {
            this.Message = message;
            this.tag = LogMessageTag.other;
        }

        public LogMessageControllers(string message, string tag) 
        {
            this.Message = message;
            this.tag = tag;      
        }
    }
}
