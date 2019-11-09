using System;
using System.Collections.Generic;
using backend.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backend.Infra.Repository
{
    public class BlogRepository
    {
        IMongoCollection<Blog> collection;


        public BlogRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Univali");
            collection = database.GetCollection<Blog>("Blogs");

        }

        public void Connection(){
            /* collection.InsertOne(new BsonDocument("Name", "Jack"));
            var list = collection.Find(new BsonDocument("Name", "Jack")).ToList();
            foreach(var document in list)   
            {
                Console.WriteLine(document["Name"]);    
            } */ 
        }

        public List<Blog> getBlogs(){

             var docs = collection.Find(_ => true).ToList();
             return docs;
        }



    }
}
