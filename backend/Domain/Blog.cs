using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Ativ4Mongo.backend.Domain
{
    public class Blog : Entity
    {
        public string username;
        public string password;
        public string title;
        public string description;
        public List<Post> posts;

    }
}
