using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Ativ4Mongo.backend.Domain
{
    public class PostSection : Entity
    {
        public ObjectId postId { get; private set; }
        public string title { get; private set; }
        public string content { get; private set; }
        public List<PostSection> subsections { get; private set; }
    }
}
