using System;
using Ativ4Mongo.backend.Domain;
using MongoDB.Bson;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class BlogsViewModel
    
    {
        public ObjectId Id { get; set; }
        public string Title { get; set; }

        public Owner Owner {get; set;}
        //Deveria ser um atributo complexo mesmo, pra ficar um doc embedded

        /*public string OwnerName {get;set;}
        public string OwnerUsername {get;set;}
        public string OwnerPassword{get;set;}*/
        
        public string Description { get; set; }


    }
}