using System;
using Ativ4Mongo.backend.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class BlogPreviewViewModel
    
    {
        public string Title { get; set; }        
        public string Username { get; set; }
        public string Description { get; set; }


    }
}