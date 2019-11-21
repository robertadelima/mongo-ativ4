using System.Linq;
using System.Collections.Generic;
using Ativ4Mongo.backend.Domain;
using MongoDB.Driver;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public class BlogRepository : Repository<Blog>
    {
        public BlogRepository() : base("Blogs") { }

        public List<Blog> Get()
        {
             var blogs = Collection.Find(_ => true).ToList();
             return blogs;
        }

        public Blog GetByUsername(string username)
        {
            return Collection
                .Find(p => p.Username == username)
                .ToList()
                .FirstOrDefault();
        }

        public bool ExistsByUsername(string username)
        {
            return GetByUsername(username) != null;
        }

        public void Add(Blog blog)
        {
           Collection.InsertOne(blog);
        }

        public bool DeleteByUsername(string username)
        {
            var result = Collection.DeleteOne(blog => blog.Username.Equals(username));
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}
