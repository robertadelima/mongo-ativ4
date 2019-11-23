using System;
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
             var blogs = Collection
                .Find(_ => true)
                .ToList()
                .OrderByDescending(
                    blog => blog.Posts?.LastOrDefault()?.PublishDate ?? DateTime.MinValue
                );

             return blogs.ToList();
        }

        public Blog GetByOwner(string owner)
        {
            return Collection
                .Find(p => p.Owner == owner)
                .ToList()
                .FirstOrDefault();
        }

        public bool ExistsByOwner(string owner)
        {
            return GetByOwner(owner) != null;
        }

        public void Add(Blog blog)
        {
           Collection.InsertOne(blog);
        }

        public bool DeleteByOwner(string owner)
        {
            var result = Collection.DeleteOne(blog => blog.Owner.Equals(owner));
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public void AddPostToBlogByOwner(string owner, Post post)
        {
            Collection.UpdateOne(
                blog => blog.Owner.Equals(owner),
                Builders<Blog>.Update.Push(blog => blog.Posts, post)
            );
        }
    }
}
