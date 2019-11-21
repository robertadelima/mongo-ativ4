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
            var posts = Collection.Find(post => post.Title == title).ToList();
            return posts;
        }

        public void RemoveByTitle(string title)
        {
            Collection.DeleteOne(post => post.Title == title);
        }

        public void Add(Post post)
        {
            Collection.InsertOne(post);
        }
    }
}
