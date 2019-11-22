using Ativ4Mongo.backend.Domain;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public class PostSectionRepository : Repository<PostSection>
    {
        public PostSectionRepository() : base("PostSections") { }

        public List<PostSection> GetByPost(Post post)
        {
            if (post == null)
            {
                return new List<PostSection>();
            }

            var posts = Collection.Find(section => post.Equals(section.Post));
            return posts.ToList();
        }

        public void Add(List<PostSection> sections)
        {
            Collection.InsertMany(sections);
        }
    }
}