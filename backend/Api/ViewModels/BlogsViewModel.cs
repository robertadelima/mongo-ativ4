using System;
using MongoDB.Bson;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class BlogsViewModel
    
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }
        //public string Owner {get; set;}

        public string Owner {get; set;}
        public string Description { get; set; }


    }
}