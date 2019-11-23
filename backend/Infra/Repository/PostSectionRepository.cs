using Ativ4Mongo.backend.Domain;
using System.Collections.Generic;
using MongoDB.Driver;
using System.Linq;

namespace Ativ4Mongo.backend.Infra.Repository
{
    public class PostSectionRepository : Repository<PostSection>
    {
        public PostSectionRepository() : base("PostSections") { }

        public List<PostSection> GetByPostId(string postId)
        {
            if (postId == null)
            {
                return new List<PostSection>();
            }

            var posts = Collection.Find(section => string.Equals(postId, section.PostId));
            return posts.ToList();
        }

        public void Add(List<PostSection> sections)
        {
            Collection.InsertMany(sections);
        }
    }
}