using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Domain
{
    public class Post : Entity
    {
        [BsonElement("title")]
        public string Title { get; private set; }

        [BsonElement("firstContent")]
        public string FirstContent { get; private set; }

        [BsonElement("publishDate")]
        public DateTime PublishDate { get; private set; }

        public List<PostSection> Sections { get; private set; }
        
        public Post(string title, string firstContent, List<PostSection> sections = null) 
        {
            this.Title = title;
            this.FirstContent = firstContent;
            PublishDate = DateTime.Now;
            Sections = sections ?? new List<PostSection>();
        }
    }
}
