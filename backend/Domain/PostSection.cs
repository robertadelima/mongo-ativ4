using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Domain
{
    public class PostSection : Entity
    {
        [BsonRepresentation(BsonType.ObjectId)] 
        public string postId { get; private set; }
        
        [BsonIgnore]
        public string Post { get; private set; }

        [BsonElement("title")]
        public string Title { get; private set; }

        [BsonElement("content")]
        public string Content { get; private set; }

        [BsonElement("subsections")]
        public List<PostSection> Subsections { get; private set; }
    }
}
