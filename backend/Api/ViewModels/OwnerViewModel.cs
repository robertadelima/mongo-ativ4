using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class OwnerViewModel
    {
        [BsonElement("name")]
        [BsonRequired()]  
        public string name { get; set; }

        //[BsonElement("credentials")]
        //[BsonRequired()]  
       // public CredentialsViewModel credentials {get; set;}
    }
}