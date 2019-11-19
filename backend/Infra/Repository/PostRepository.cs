using System;
using Ativ4Mongo.backend.Domain;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Ativ4Mongo.backend.Api.ViewModels;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository() : base("Posts") { }

        public List<Post> getPosts()
        {
             var docs = Collection.Find(_ => true).ToList();
             return docs;
        }

        //Provavelmente será trocado para Find por id ou owner.username
        //Só fiz para testar a estrutura
        public List<Post> getPostsByTitle(string pTitle)
        {
            var docs = Collection.Find(p => p.title == pTitle).ToList();
            return docs;
        }

        public void Remove(string pTitle)
        {
            Collection.DeleteOne(post=> post.title == pTitle);
        }

        public void Add(Post post)
        {
            Collection.InsertOne(post);
        }
    }
}
