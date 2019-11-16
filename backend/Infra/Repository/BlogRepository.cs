using System;
using System.Collections.Generic;
using Ativ4Mongo.backend.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ativ4Mongo.backend.Infra.Repository
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
            
        }

        public List<Blog> getBlogs(){

             var docs = collection.Find(_ => true).ToList();
             Console.WriteLine(docs);
             return docs;
        }



    }
}
