using System;
using MongoDB.Bson;

namespace Ativ4Mongo.backend.Domain
{
    public class PostSection : Entity
    {
        public ObjectId postId;
        public string title;
        public string content;
        public PostSection[] subsections;

    }
}
