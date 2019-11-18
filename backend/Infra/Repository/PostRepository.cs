using System;
using Ativ4Mongo.backend.Domain;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Ativ4Mongo.backend.Api.ViewModels;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public class PostRepository
    {
        IMongoDatabase database;
        IMongoCollection<Post> collection;
        IMongoCollection<PostPreviewViewModel> collection2;


        public PostRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("Univali");
            collection = database.GetCollection<Post>("Posts");
            collection2 = database.GetCollection<PostPreviewViewModel>("Posts");
        }
         public void Connection(){

        }


        public List<Post> getPosts(){

             var docs = collection.Find(_ => true).ToList();

             return docs;
        }


        //Provavelmente será trocado para Find por id ou owner.username
        //Só fiz para testar a estrutura
        public List<Post> getPostsByTitle(string pTitle){
            var docs = collection.Find(p => p.title == pTitle).ToList();
            return docs;
        }

        public void Remove(string pTitle)
        {
            collection.DeleteOne(post=> post.title == pTitle);
        }

        public void Add(PostPreviewViewModel post)
        {
            collection2.InsertOne(post);
        }
    }
}
