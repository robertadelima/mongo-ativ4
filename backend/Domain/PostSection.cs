using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Domain
{
    public class PostSection : Entity
    {
        [BsonRepresentation(BsonType.ObjectId)] 
        public string PostId { get; private set; }
        
        [BsonIgnore]
        public Post Post { get; private set; }

        [BsonElement("title")]
        public string Title { get; private set; }

        [BsonElement("content")]
        public string Content { get; private set; }

        [BsonElement("subsections")]
        public List<PostSection> Subsections { get; private set; }

        public PostSection(
            Post post, string title, string content, List<PostSection> subsections)
        {
            Post = post;
            PostId = post?.Id;
            Title = title;
            Content = content;
            Subsections = subsections;
        }
    }
}
