using Amazon.Runtime.Internal;
using LogModel;
using MongoDB.Driver;

namespace LogService.Data
{
    public class LogRepository
    {
        private string connectionString = "mongodb://mongo:27017/";
        private const string dbName = "retailStoreLogsDb";
        private const string collectionName = "logs";
        private IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            return db.GetCollection<T>(collection);
        }

        public async Task WriteMessage(LogMessage logMessage)
        {
            await ConnectToMongo<LogMessage>(collectionName).InsertOneAsync(logMessage);
        }

        public async Task<List<LogMessageBase>> ReadMessagesByTag(string tag)
        {
            return await ConnectToMongo<LogMessageBase>(collectionName).Find(c => c.tag == tag).ToListAsync();
        }
    }
}
