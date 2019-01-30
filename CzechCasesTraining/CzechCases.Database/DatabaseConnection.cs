using MongoDB.Driver;

namespace CzechCases.Database
{
    public class DatabaseConnection
    {
        private readonly IMongoDatabase _connection;

        internal IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings settings = null)
        {
            return _connection.GetCollection<TDocument>(name, settings);
        }

        private DatabaseConnection(IMongoDatabase connection)
        {
            _connection = connection;
        }

        public static DatabaseConnection CreateConnection(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            return new DatabaseConnection(client.GetDatabase(dbName));
        }

        public static DatabaseConnection CreateConnection(string dbName, string server, int port)
        {
            var client = new MongoClient(new MongoClientSettings() { ApplicationName = dbName, Server = new MongoServerAddress(server, port) });
            return new DatabaseConnection(client.GetDatabase(dbName));
        }
    }
}