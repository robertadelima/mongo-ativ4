using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Api.ViewModels
{
    public class CredentialsViewModel
    {

        //[BsonElement("username")]
        //[BsonRequired()]  
        public string username { get; set; }

        //[BsonElement("password")]
        //[BsonRequired()]  
        public string password { get; set; }
    }
}