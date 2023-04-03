using APImongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace APImongoDB.Repository
{
    public class Context : IDisposable
    {
        public IMongoDatabase _database { get; set; }
        public IMongoClient _client { get; set; }

        public Context(IOptions<Settings> settings)
        {
            _client = new MongoClient(settings.Value.ConnectionString);
            if (_client != null)
            {
                _database = _client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Alerta> Alerta
        {
            get { return _database.GetCollection<Alerta>("alertas"); }
        }
        public IMongoCollection<Usuario> Usuario
        {
            get { return _database.GetCollection<Usuario>("usuario"); }
        }

        public void Dispose()
        {
            _database = null;
            _client = null;
        }
    }

    public class Settings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
