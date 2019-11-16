using System;
using MongoDB.Bson;

namespace Ativ4Mongo.backend.Domain
{
    public class Post : Entity
    {
        public ObjectId Id;
        public string title;
        public string firstContent;
        public DateTime publishDate;

    }
}
