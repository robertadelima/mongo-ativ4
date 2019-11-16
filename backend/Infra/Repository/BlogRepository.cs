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

             return docs;
        }

        //Provavelmente será trocado para Find por id ou owner.username
        //Só fiz para testar a estrutura
        public List<Blog> getBlogsByTitle(string pTitle){
            var docs = collection.Find(p => p.title == pTitle).ToList();
            return docs;
        }

        



    }
}
