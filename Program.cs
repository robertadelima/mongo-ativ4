using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ativ4Mongo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Program().testConnection();
        }

        public void testConnection(){
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
