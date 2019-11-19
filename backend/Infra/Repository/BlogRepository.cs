using System.Linq;
using System.Collections.Generic;
using Ativ4Mongo.backend.Domain;
using MongoDB.Driver;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public class BlogRepository : Repository<Blog>
    {
        public BlogRepository() : base("Blogs") { }

        public List<Blog> GetBlogs()
        {
             var blogs = Collection.Find(_ => true).ToList();
             return blogs;
        }

        public Blog GetBlogByUsername(string username)
        {
            return Collection.Find(p => p.username == username).ToList().FirstOrDefault();
        }

        public bool UserExists(string pUsername)
        {
            return Collection.Find(p => p.username == pUsername).ToList().FirstOrDefault() != null;
        }

        public void Add(Blog blog)
        {
           Collection.InsertOne(blog);
        }
    }
}
