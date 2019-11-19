using System;
using Ativ4Mongo.backend.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public abstract class Repository<T> where T : Entity
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;
        protected IMongoCollection<T> Collection { get; set; }

        public Repository(string collectionName)
        {
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("Univali");
            
            Collection = database.GetCollection<T>(collectionName);
        }
    }

        
    
}
