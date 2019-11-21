using Ativ4Mongo.backend.Domain;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public class PostRepository : Repository<Post>
    {
        public PostRepository() : base("Posts") { }

        public List<Post> GetByTitle(string title)
        {
            var docs = Collection.Find(post => post.Title == title).ToList();
            return docs;
        }

        public void Remove(string title)
        {
            Collection.DeleteOne(post => post.Title == title);
        }

        public void Add(Post post)
        {
            Collection.InsertOne(post);
        }
    }
}
