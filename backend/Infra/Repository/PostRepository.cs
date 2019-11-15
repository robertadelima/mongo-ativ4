using System;
using Ativ4Mongo.backend.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public class PostRepository
    {
        IMongoCollection<BsonDocument> collection;


        public PostRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
        }
         public void Connection(){
             var client = new MongoClient("mongodb://localhost:27017");
             var database = client.GetDatabase("foo");
             var collection = database.GetCollection<BsonDocument>("bar");

            collection.InsertOne(new BsonDocument("Name", "Jack"));

            var list = collection.Find(new BsonDocument("Name", "Jack")).ToList();

            foreach(var document in list)   
            {
                Console.WriteLine(document["Name"]);    
            }   
        }
    }
}
