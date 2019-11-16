using System;
using MongoDB.Bson;

namespace Ativ4Mongo.backend.Domain
{
    public class Blog : Entity
    {
        public Owner owner;
        //public Post[] posts;

        //public string owner;
        public string title;
        public string description;
        

    }
}
