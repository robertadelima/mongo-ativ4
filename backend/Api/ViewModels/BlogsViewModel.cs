using System;
using Ativ4Mongo.backend.Domain;
using MongoDB.Bson;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class BlogsViewModel
    
    {
        /* public BlogsViewModel(string pTitle, Owner pOwner, string pDescription){
            Title = pTitle;
            Owner = pOwner;
            Description = pDescription;
        }*/
        public ObjectId Id { get; set; }
        public string Title { get; set; }

        public Owner Owner {get; set;}
        
        public string Description { get; set; }


    }
}