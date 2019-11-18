using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class PostsViewModel
    {
        public ObjectId Id { get; set; } 
        public string Title { get; set; }
        public string FirstContent { get; set; }
        public DateTime publishDate { get; set; }

    }
}