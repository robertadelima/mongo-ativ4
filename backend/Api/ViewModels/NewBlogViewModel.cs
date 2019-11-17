using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class NewBlogViewModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }
}