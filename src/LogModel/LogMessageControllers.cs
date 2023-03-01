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
        public LogMessageControllers(string message, string serviceName)
        {
            this.Message = message;
            this.ServiceName = serviceName;
            this.tag = LogMessageTag.other;
        }
        public LogMessageControllers(string message, string serviceName, string tag) 
        {
            this.Message = message;
            this.ServiceName = serviceName;
            this.tag = tag;      
        }
    }
}
