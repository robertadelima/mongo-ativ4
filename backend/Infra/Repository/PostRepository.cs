using System;
using Ativ4Mongo.backend.Domain;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public class PostRepository
    {
        IMongoCollection<Post> collection;


        public PostRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Univali");
            collection = database.GetCollection<Post>("Posts");
        }
         public void Connection(){
             /*var client = new MongoClient("mongodb://localhost:27017");
             var database = client.GetDatabase("foo");
             var collection = database.GetCollection<BsonDocument>("bar");

            collection.InsertOne(new BsonDocument("Name", "Jack"));

            var list = collection.Find(new BsonDocument("Name", "Jack")).ToList();

            foreach(var document in list)   
            {
                Console.WriteLine(document["Name"]);    
            }   */
        }


        public List<Post> getPosts(){

             var docs = collection.Find(_ => true).ToList();

             return docs;
        }

        public void Add(Post post)
        {
            collection.InsertOne(post);
        }
    }
}
