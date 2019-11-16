using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class PostsViewModel
    {
        [BsonId()]
        public ObjectId Id { get; set; }
        
        [BsonElement("title")]
        [BsonRequired()]
        public string Title { get; set; }

        //public string Owner { get; set; }

        [BsonElement("firstContent")]
        [BsonRequired()]    
        public string FirstContent { get; set; }

        //public DateTime publishDate { get; set; }
    }
}