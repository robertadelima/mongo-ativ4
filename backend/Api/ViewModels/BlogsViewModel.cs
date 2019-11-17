using System;
using Ativ4Mongo.backend.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class BlogsViewModel
    
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }        
        public string Username;
        public string Password;
        public string Description { get; set; }


    }
}