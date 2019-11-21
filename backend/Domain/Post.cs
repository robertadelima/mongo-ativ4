using System;
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

        public Post(string title, string firstContent)
        {
            this.Title = title;
            this.FirstContent = firstContent;
            PublishDate = DateTime.Now;
        } 
    }
}
