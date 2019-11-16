using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ativ4Mongo.backend.Domain
{
    public class Post : Entity
    {
        public Post(){

        }
        public Post(string pTitle, string pFirstContent){
            title = pTitle;
            firstContent = pFirstContent;
        } 

       
        public string title;

        public string firstContent;

        //public DateTime publishDate;

    }
}
