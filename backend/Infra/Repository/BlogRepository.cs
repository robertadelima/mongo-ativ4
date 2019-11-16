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
        IMongoCollection<Blog> collectionBlog;
        IMongoCollection<BlogsViewModel> collectionBlogViewModel;


        public BlogRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Univali");
            collectionBlog = database.GetCollection<Blog>("Blogs");
            collectionBlogViewModel = database.GetCollection<BlogsViewModel>("Blogs");

        }

        public void Connection(){
            
        }

        public List<Blog> getBlogs(){

             var docs = collectionBlog.Find(_ => true).ToList();

             return docs;
        }

        //Provavelmente será trocado para Find por id ou owner.username
        //Só fiz para testar a estrutura
        public List<Blog> getBlogsByTitle(string pTitle){
            var docs = collectionBlog.Find(p => p.title == pTitle).ToList();
            return docs;
        }

        public void Add(BlogsViewModel blog){
            collectionBlogViewModel.InsertOne(blog);
        }

        



    }
}
