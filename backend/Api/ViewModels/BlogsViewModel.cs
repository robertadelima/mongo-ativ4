using System;
using Ativ4Mongo.backend.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class BlogsViewModel
    
    {
        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        [BsonRequired()]
        public string Title { get; set; }

        [BsonElement("owner")]
        [BsonRequired()]   
        public OwnerViewModel Owner {get; set;}

        [BsonElement("description")]
        [BsonRequired()]  
        public string Description { get; set; }


    }
}