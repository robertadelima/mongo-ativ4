using System.Linq;
using System;
using System.Collections.Generic;
using Ativ4Mongo.backend.Api.ViewModels;
using Ativ4Mongo.backend.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public class BlogRepository
    {
        IMongoDatabase database;


        public BlogRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("Univali");
        }

        public void Connection(){
            
        }

        public List<Blog> GetBlogs(){

             var docs = database.GetCollection<Blog>("Blogs").Find(_ => true).ToList();

             return docs;
        }

        //Provavelmente será trocado para Find por id ou owner.username
        //Só fiz para testar a estrutura
        public Blog GetBlogByUsername(string username){
            return database.GetCollection<Blog>("Blogs").Find(p => p.username == username).ToList().FirstOrDefault();
        }

        public bool UserExists(string pUsername){
            return database.GetCollection<Blog>("Blogs").Find(p => p.username == pUsername).ToList().FirstOrDefault() != null;
        }

        public void Add(Blog blog){
            database.GetCollection<Blog>("Blogs").InsertOne(blog);
        }

        



    }
}
